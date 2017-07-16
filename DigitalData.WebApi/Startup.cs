using DigitalData.AppService;
using DigitalData.Domain.Entities.User.Contracts;
using DigitalData.WebApi.Provider;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DigitalData.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(config);
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