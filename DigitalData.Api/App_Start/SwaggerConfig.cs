using System.Web.Http;
using DigitalData.Api;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DigitalData.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {            
            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...
        }
    }
}