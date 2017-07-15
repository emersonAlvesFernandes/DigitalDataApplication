using DigitalData.Api.Providers;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DigitalData.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ConfigureWebApi(config);
            
            ConfigureOAuth(app);
            

            // Permite requisições de qualquer URL externa
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Informa que está usando um web api
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //Swashbuckle.Bootstrapper.Init();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //config.Routes.MapHttpRoute(
            //    name: "Swagger UI",
            //    routeTemplate: "",
            //    defaults: null,
            //    constraints: null,
            //    handler: new RedirectHandler(message => message.RequestUri.ToString().TrimEnd('/'), "swagger/ui/index"));
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
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),

                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        
    }
}