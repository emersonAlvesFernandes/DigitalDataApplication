using DigitalData.WebApi.Models.Authentication;
using DigitalData.WebApi.Provider;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApi.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [Route("signin")]
        //[ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> SignInAsync(AuthUser user)
        {
            var pairs = new FormUrlEncodedContent(
               new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", user.Username),
                    new KeyValuePair<string, string>("password", user.Password),
               });

            var request = HttpContext.Current.Request;
            
            var appPath = string.Format("{0}://{1}{2}{3}",
                                    request.Url.Scheme,
                                    request.Url.Host,
                                    request.Url.Port == 80
                                        ? string.Empty
                                        : ":" + request.Url.Port,
                                    request.ApplicationPath);
                        
            var securityPath = WebConfigurationManager.AppSettings["securityPath"];

            //var endpoint = @"http://localhost:55542/api/security/token";   
            var endpoint = string.Format("{0}{1}", appPath, securityPath);

            HttpResponseMessage response;
            using (var client = new HttpClient())
                response = await client.PostAsync(endpoint, pairs);
            
            var content = await response.Content.ReadAsStringAsync();

            return response;
        }
    }
}
