﻿#region copyright
// Copyright 2017 Habart Thierry
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

using SimpleIdentityServer.Core.Bus;
using SimpleIdentityServer.Core.Events;
using SimpleIdentityServer.Core.Models;
using SimpleIdentityServer.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace SimpleIdentityServer.Core.Handlers
{
    public class AuthorizationHandler : IHandle<AuthorizationRequestReceived>, IHandle<AuthorizationGranted>, IHandle<ResourceOwnerAuthenticated>, IHandle<ConsentAccepted>, IHandle<ConsentRejected>
    {
        private readonly IEventAggregateRepository _repository;
        private readonly IPayloadSerializer _serializer;

        public AuthorizationHandler(IEventAggregateRepository repository, IPayloadSerializer serializer)
        {
            _repository = repository;
            _serializer = serializer;
        }

        public async Task Handle(AuthorizationRequestReceived message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var payload = _serializer.GetPayload(message);
            await _repository.Add(new EventAggregate
            {
                Id = message.Id,
                AggregateId = message.ProcessId,
                Description = "Start authorization process",
                CreatedOn = DateTime.UtcNow,
                Payload = payload,
                Order = message.Order
            });
        }

        public async Task Handle(AuthorizationGranted message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var payload = _serializer.GetPayload(message);
            await _repository.Add(new EventAggregate
            {
                Id = message.Id,
                AggregateId = message.ProcessId,
                Description = "Authorization granted",
                CreatedOn = DateTime.UtcNow,
                Payload = payload,
                Order = message.Order
            });
        }

        public async Task Handle(ResourceOwnerAuthenticated message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var payload = _serializer.GetPayload(message);
            await _repository.Add(new EventAggregate
            {
                Id = message.Id,
                AggregateId = message.AggregateId,
                Description = "Resource owner is authenticated",
                CreatedOn = DateTime.UtcNow,
                Payload = payload,
                Order = message.Order
            });
        }

        public async Task Handle(ConsentAccepted message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var payload = _serializer.GetPayload(message);
            await _repository.Add(new EventAggregate
            {
                Id = message.Id,
                AggregateId = message.ProcessId,
                Description = "Consent accepted",
                CreatedOn = DateTime.UtcNow,
                Payload = payload,
                Order = message.Order
            });
        }

        public async Task Handle(ConsentRejected message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _repository.Add(new EventAggregate
            {
                Id = message.Id,
                AggregateId = message.ProcessId,
                Description = "Consent rejected",
                CreatedOn = DateTime.UtcNow,
                Order = message.Order
            });
        }
    }
}
