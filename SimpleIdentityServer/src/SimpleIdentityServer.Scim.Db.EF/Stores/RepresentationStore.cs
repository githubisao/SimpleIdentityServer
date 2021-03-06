﻿#region copyright
// Copyright 2015 Habart Thierry
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using Microsoft.EntityFrameworkCore;
using SimpleIdentityServer.Scim.Core.Models;
using SimpleIdentityServer.Scim.Core.Stores;
using SimpleIdentityServer.Scim.Db.EF.Extensions;
using SimpleIdentityServer.Scim.Db.EF.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = SimpleIdentityServer.Scim.Db.EF.Models;

namespace SimpleIdentityServer.Scim.Db.EF.Stores
{
    internal class RepresentationStore : IRepresentationStore
    {
        private readonly ScimDbContext _context;
        private readonly ITransformers _transformers;

        public RepresentationStore(ScimDbContext context, ITransformers transformers)
        {
            _context = context;
            _transformers = transformers;
        }

        public async Task<bool> AddRepresentation(Representation representation)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false))
            {
                var result = true;
                try
                {
                    var record = new Model.Representation
                    {
                        Id = representation.Id,
                        Created = representation.Created,
                        LastModified = representation.LastModified,
                        ResourceType = representation.ResourceType,
                        Version = representation.Version,
                        Attributes = GetRepresentationAttributes(representation)
                    };
                    _context.Representations.Add(record);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    transaction.Commit();
                }
                catch
                {
                    result = false;
                    transaction.Rollback();
                }

                return result;
            }
        }

        public async Task<Representation> GetRepresentation(string id)
        {
            try
            {
                var representation = await _context.Representations
                    .Include(r => r.Attributes).ThenInclude(a => a.Children).ThenInclude(a => a.Children)
                    .Include(r => r.Attributes).ThenInclude(a => a.SchemaAttribute).ThenInclude(s => s.Children)
                    .FirstOrDefaultAsync(r => r.Id == id)
                    .ConfigureAwait(false);
                if (representation == null)
                {
                    return null;
                }

                var record = representation.ToDomain();
                record.Attributes = GetRepresentationAttributes(representation);
                return record;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Representation>> GetRepresentations(string resourceType)
        {
            try
            {
                var representations = await _context.Representations
                    .Include(r => r.Attributes).ThenInclude(a => a.Children).ThenInclude(a => a.Children)
                    .Include(r => r.Attributes).ThenInclude(a => a.SchemaAttribute).ThenInclude(s => s.Children)
                    .Where(r => r.ResourceType == resourceType).ToListAsync().ConfigureAwait(false);
                var lst = new List<Representation>();
                foreach(var representation in representations)
                {
                    var record = representation.ToDomain();
                    record.Attributes = GetRepresentationAttributes(representation);
                    lst.Add(record);
                }

                return lst;
            }
            catch
            {
                return new Representation[0];
            }
        }

        public async Task<bool> RemoveRepresentation(Representation representation)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false))
            {
                var result = true;
                try
                {
                    var record = await _context.Representations.FirstOrDefaultAsync(r => r.Id == representation.Id).ConfigureAwait(false);
                    if (record == null)
                    {
                        return false;
                    }

                    _context.Representations.Remove(record);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    transaction.Commit();
                }
                catch
                {
                    result = false;
                    transaction.Rollback();
                }

                return result;
            }
        }

        public async Task<bool> UpdateRepresentation(Representation representation)
        {
            if (representation == null)
            {
                return false;
            }

            using (var transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false))
            {
                var result = true;
                try
                {
                    var record = await _context.Representations
                        .Include(r => r.Attributes).ThenInclude(r => r.Children).ThenInclude(r => r.Children).ThenInclude(r => r.Children)
                        .FirstOrDefaultAsync(r => r.Id == representation.Id).ConfigureAwait(false);
                    if (record == null)
                    {
                        return false;
                    }

                    record.SetData(representation);
                    if (record.Attributes != null)
                    {
                        RemoveAttributes(record.Attributes);
                        record.Attributes.Clear();
                    }

                    record.Attributes.AddRange(GetRepresentationAttributes(representation));
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    transaction.Commit();
                }
                catch
                {
                    result = false;
                    transaction.Rollback();
                }

                return result;
            }
        }

        private List<RepresentationAttribute> GetRepresentationAttributes(Model.Representation representation)
        {
            if (representation.Attributes == null)
            {
                return new List<RepresentationAttribute>();
            }

            var result = new List<RepresentationAttribute>();
            foreach(var attribute in representation.Attributes)
            {
                var transformed = _transformers.Transform(attribute);
                if (transformed == null)
                {
                    continue;
                }

                result.Add(transformed);
            }

            return result;
        }

        private List<Model.RepresentationAttribute> GetRepresentationAttributes(Representation representation)
        {
            if (representation.Attributes == null)
            {
                return new List<Model.RepresentationAttribute>();
            }

            var result = new List<Model.RepresentationAttribute>();
            foreach (var attribute in representation.Attributes)
            {
                var transformed = _transformers.Transform(attribute);
                if (transformed == null)
                {
                    continue;
                }

                result.Add(transformed);
            }

            return result;
        }

        private void RemoveAttributes(List<Model.RepresentationAttribute> attributes)
        {
            foreach(var attribute in attributes)
            {
                if (attribute.Children != null)
                {
                    RemoveAttributes(attribute.Children);
                }
            }

            _context.RemoveRange(attributes);
        }
    }
}
