﻿using System.ComponentModel.Composition;

using SimpleIdentityServer.Common;
using SimpleIdentityServer.DataAccess.Fake.Repositories;
using SimpleIdentityServer.Core.Repositories;

namespace SimpleIdentityServer.DataAccess.Fake
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegister register)
        {
            register.RegisterType<IClientRepository, FakeClientRepository>();
            register.RegisterType<IScopeRepository, FakeScopeRepository>();
            register.RegisterType<IResourceOwnerRepository, FakeResourceOwnerRepository>();
            register.RegisterType<IGrantedTokenRepository, FakeGrantedTokenRepository>();
        }
    }
}
