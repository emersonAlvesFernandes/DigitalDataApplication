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
            HttpConfiguration config = new HttpConfiguration();
            
            ConfigureWebApi(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            SwaggerConfig.Register(config);

        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(                        
                name: "Default",                        
                routeTemplate: "api/{controller}/{id}",            
                defaults: new { id = RouteParameter.Optional}
            );

            //config.Routes.MapHttpRoute(            
            //name: "DefaultApi",
            //routeTemplate: "api/{controller}/{id}",            
            //defaults: new { id = RouteParameter.Optional }
            //);


        }
    }
}