using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DigitalData.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
