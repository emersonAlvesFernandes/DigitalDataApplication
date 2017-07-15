using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.Api.Controllers
{
    [RoutePrefix("api/default")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Get()
        {
            return this.Ok("teste");
        }
    }
}
