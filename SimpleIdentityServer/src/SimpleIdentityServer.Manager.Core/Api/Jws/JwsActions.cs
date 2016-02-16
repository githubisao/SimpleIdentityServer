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

using SimpleIdentityServer.Manager.Core.Api.Jws.Actions;
using SimpleIdentityServer.Manager.Core.Parameters;
using SimpleIdentityServer.Manager.Core.Results;
using System;

namespace SimpleIdentityServer.Manager.Core.Api.Jws
{
    public interface IJwsActions
    {
        JwsInformationResult GetJwsInformation(GetJwsParameter getJwsParameter);
    }

    public class JwsActions : IJwsActions
    {
        private readonly IGetJwsInformationAction _getJwsInformationAction;

        #region Constructor

        public JwsActions(IGetJwsInformationAction getJwsInformationAction)
        {
            _getJwsInformationAction = getJwsInformationAction;
        }

        #endregion
        
        #region Public methods

        public JwsInformationResult GetJwsInformation(GetJwsParameter getJwsParameter)
        {
            if (getJwsParameter == null || string.IsNullOrWhiteSpace(getJwsParameter.Jws))
            {
                throw new ArgumentNullException(nameof(getJwsParameter));
            }

            return _getJwsInformationAction.Execute(getJwsParameter);
        }

        #endregion
    }
}
