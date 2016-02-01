using System;
using System.Linq;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using SimpleIdentityServer.Api.Configuration;
using SimpleIdentityServer.Core;
using SimpleIdentityServer.Core.Configuration;
using SimpleIdentityServer.Core.Jwt;
using SimpleIdentityServer.Core.Protector;
using SimpleIdentityServer.Core.Services;
using SimpleIdentityServer.DataAccess.Fake;
using SimpleIdentityServer.DataAccess.SqlServer;
using SimpleIdentityServer.DataAccess.Fake.Extensions;
using SimpleIdentityServer.Host.Parsers;
using SimpleIdentityServer.Logging;
using Swashbuckle.SwaggerGen;
using Microsoft.AspNet.Identity;
using SimpleIdentityServer.Host.MiddleWare;
using Microsoft.AspNet.Http;

namespace SimpleIdentityServer.Host 
{
    public static class SimpleIdentityServerHostExtensions 
    {
        #region Public static methods
        
        public static void AddSimpleIdentityServer(
            this IServiceCollection serviceCollection, 
            SimpleIdentityServerHostOptions options) 
        {
            if (options == null) {
                throw new ArgumentNullException("options");
            }
            
            if (options.DataSourceType == DataSourceTypes.InMemory) 
            {
                var clients = options.Clients.Select(c => c.ToFake()).ToList();
                var jsonWebKeys = options.JsonWebKeys.Select(j => j.ToFake()).ToList();
                var resourceOwners = options.ResourceOwners.Select(r => r.ToFake()).ToList();
                var scopes = options.Scopes.Select(s => s.ToFake()).ToList();
                var translations = options.Translations.Select(t => t.ToFake()).ToList();
                FakeDataSource.Instance().Clients = clients;
                FakeDataSource.Instance().JsonWebKeys = jsonWebKeys;
                FakeDataSource.Instance().ResourceOwners = resourceOwners;
                FakeDataSource.Instance().Scopes = scopes;
                FakeDataSource.Instance().Translations = translations;
                serviceCollection.AddSimpleIdentityServerFake();
            }
            else 
            {
                serviceCollection.AddSimpleIdentityServerSqlServer();
                serviceCollection.AddTransient<SimpleIdentityServerContext>((a) => new SimpleIdentityServerContext(options.ConnectionString));
            }
            
            ConfigureSimpleIdentityServer(serviceCollection, options);
        }
        
        public static void UseSimpleIdentityServer(
            this IApplicationBuilder app,
            SimpleIdentityServerHostOptions options) 
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.UseIISPlatformHandler(opts => opts.AuthenticationDescriptions.Clear());
            app.UseCookieAuthentication(opts => {
                opts.AuthenticationScheme = "SimpleIdentityServerAuthentication";
                opts.AutomaticAuthenticate = true;
            });

            app.UseStaticFiles();

            if (options.IsDeveloperModeEnabled)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseSimpleIdentityServerExceptionHandler(new ExceptionHandlerMiddlewareOptions
                {
                    SimpleIdentityServerEventSource = SimpleIdentityServerEventSource.Log
                });
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            
            if (options.IsSwaggerEnabled)
            {
                app.UseSwaggerGen();
                if (!string.IsNullOrWhiteSpace(options.SwaggerUrl))
                {
                    app.UseSwaggerUi(swaggerUrl : options.SwaggerUrl);
                }
                else
                {
                    app.UseSwaggerUi();
                }
            }        
        }
        
        #endregion
        
        #region Private static methods       
        
        /// <summary>
        /// Add all the dependencies needed to run Simple Identity Server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        private static void ConfigureSimpleIdentityServer(
            IServiceCollection services,
            SimpleIdentityServerHostOptions options) 
        {            
            services.AddSimpleIdentityServerCore();
            services.AddSimpleIdentityServerJwt();
            
            var logging = SimpleIdentityServerEventSource.Log;
            services.AddTransient<ICacheManager, CacheManager>();
            services.AddTransient<ICertificateStore, CertificateStore>();
            services.AddTransient<IResourceOwnerService, InMemoryUserService>();
            services.AddTransient<IRedirectInstructionParser, RedirectInstructionParser>();
            services.AddTransient<IActionResultParser, ActionResultParser>();
            services.AddTransient<ISimpleIdentityServerConfigurator, ConcreteSimpleIdentityServerConfigurator>();
            services.AddInstance<ISimpleIdentityServerEventSource>(logging);
            
            if (options.IsSwaggerEnabled)
            {
                services.AddSwaggerGen();
                services.ConfigureSwaggerDocument(opts => {
                    opts.SingleApiVersion(new Info
                    {
                        Version = "v1",
                        Title = "Simple Identity Server",
                        TermsOfService = "None"
                    });
                });
            }
        }
        
        #endregion
    }
}