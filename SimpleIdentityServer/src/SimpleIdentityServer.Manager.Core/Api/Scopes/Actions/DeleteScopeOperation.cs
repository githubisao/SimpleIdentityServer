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

using SimpleIdentityServer.Core.Repositories;
using SimpleIdentityServer.Logging;
using SimpleIdentityServer.Manager.Core.Errors;
using SimpleIdentityServer.Manager.Core.Exceptions;
using System;

namespace SimpleIdentityServer.Manager.Core.Api.Scopes.Actions
{
    public interface IDeleteScopeOperation
    {
        bool Execute(string scopeName);
    }

    internal class DeleteScopeOperation : IDeleteScopeOperation
    {
        private readonly IScopeRepository _scopeRepository;

        private readonly IManagerEventSource _managerEventSource;

        #region Constructor

        public DeleteScopeOperation(
            IScopeRepository scopeRepository,
            IManagerEventSource managerEventSource)
        {
            _scopeRepository = scopeRepository;
            _managerEventSource = managerEventSource;
        }

        #endregion

        #region Public methods

        public bool Execute(string scopeName)
        {
            _managerEventSource.StartToRemoveScope(scopeName);
            if (string.IsNullOrWhiteSpace(scopeName))
            {
                throw new ArgumentNullException(nameof(scopeName));
            }

            var scope = _scopeRepository.GetScopeByName(scopeName);
            if (scope == null)
            {
                throw new IdentityServerManagerException(ErrorCodes.InvalidRequestCode,
                    string.Format(ErrorDescriptions.TheScopeDoesntExist, scopeName));
            }

            var res = _scopeRepository.DeleteScope(scope);
            if (res)
            {
                _managerEventSource.FinishToRemoveScope(scopeName);
            }

            return res;
        }

        #endregion
    }
}
