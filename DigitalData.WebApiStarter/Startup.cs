using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using DigitalData.WebApiStarter.App_Start;
using Compusight.MoveDesk.UserManagementApi.Configuration;
using Microsoft.Owin.Security.OAuth;
using System;
using DigitalData.WebApiStarter.Provider;

[assembly: OwinStartup(typeof(DigitalData.WebApiStarter.Startup))]

namespace DigitalData.WebApiStarter
{
    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            CorsConfig.ConfigureCors(ConfigurationManager.AppSettings["cors"]);
            app.UseCors(CorsConfig.Options);

            var configuration = new HttpConfiguration();

            AutofacConfig.Configure(configuration);
            app.UseAutofacMiddleware(AutofacConfig.Container);

            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);
            ServiceConfig.Configure(configuration);
            SwaggerConfig.Configure(configuration);

            ConfigureOAuth(app);

            app.UseWebApi(configuration);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                // Permite requisições sem https
                AllowInsecureHttp = true,

                // URL de autenticação
                TokenEndpointPath = new Microsoft.Owin.PathString("/api/security/token"),

                //Duração de Token Valido
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(12),

                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}