using System;
using System.CodeDom;
using System.Web.Http;
using System.Xml.XPath;
using Swashbuckle.Application;
using System.Reflection;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Filters;

namespace Compusight.MoveDesk.UserManagementApi.Configuration
{
    /// <summary>
    /// Represent Swagger configuration.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Configures Swagger API 
        /// </summary>
        /// <param name="configuration">Instance of <see cref="HttpConfiguration"/>.</param>
        public static void Configure(HttpConfiguration configuration)
        {
            configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "My.Api");
                    c.PrettyPrint();
                    c.IncludeXmlComments(() => new XPathDocument(GetXmlDocumentationPath()));
                })
                .EnableSwaggerUi(c => { });
        }

        private static string GetXmlDocumentationPath()
        {
            var path =
                string.Format("{0}bin\\{1}.xml", AppDomain.CurrentDomain.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name);

            return path;
        }

        private class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                var filterPipeline = apiDescription
                        .ActionDescriptor
                        .GetFilterPipeline();

                var isAuthorized = filterPipeline
                        .Select(filterInfo => filterInfo.Instance)
                        .Any(filter => filter is IAuthorizationFilter);

                var allowAnonymous = apiDescription
                        .ActionDescriptor
                        .GetCustomAttributes<AllowAnonymousAttribute>()
                        .Any();

                if (!isAuthorized)
                    return;

                if (allowAnonymous)
                    return;

                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();

                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token",
                    required = true,
                    type = "string"
                });
            }
        }
    }
}