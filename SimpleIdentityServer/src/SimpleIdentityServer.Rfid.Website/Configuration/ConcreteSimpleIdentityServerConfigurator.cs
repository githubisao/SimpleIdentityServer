﻿#region copyright
// Copyright 2016 Habart Thierry
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

using System;
using SimpleIdentityServer.Core.Configuration;
using Microsoft.AspNetCore.Http;
using SimpleIdentityServer.Host.Extensions;

namespace SimpleIdentityServer.Rfid.Website.Configuration
{
    public class ConcreteSimpleIdentityServerConfigurator : ISimpleIdentityServerConfigurator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConcreteSimpleIdentityServerConfigurator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string DefaultLanguage()
        {
            return "en";
        }

        public double GetAuthorizationCodeValidityPeriodInSeconds()
        {
            return 3600;
        }

        public string GetIssuerName()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return request.GetAbsoluteUriWithVirtualPath();
        }

        public double GetTokenValidityPeriodInSeconds()
        {
            return 3600;
        }
    }
}