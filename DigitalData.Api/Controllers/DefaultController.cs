using DigitalData.Api.ViewModels;
using DigitalData.AppService;
using DigitalData.AppService.Contracts;
using DigitalData.Domain.Default;
using FastMapper;
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
    //[RoutePrefix("api/DefaultData")]
    public class DefaultController : ApiController
    {
        private readonly IDefaultDataAppService appservice;

        public DefaultController(IDefaultDataAppService appservice)
        {
            this.appservice = appservice;
        }

        public DefaultController()
        {
            this.appservice = new DefaultDataAppService();
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> CreateAsync([FromBody] DefaultDataCreate defaultCreate,
        [FromUri] int campaignId)
        {
            
            var defaultCreateEntity =
                TypeAdapter.Adapt<DefaultDataCreate, DefaultData>(defaultCreate);

            var createSucceed = await Task.Run(() => appservice.Create(defaultCreateEntity));            

            return this.Ok(createSucceed);
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<DefaultData>))]
        public async Task<IHttpActionResult> GetAllAsync()
        {            
            var collection = await Task.Run(() => appservice.Read());

            return this.Ok(collection);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(DefaultData))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri] int id)
        {
            var entity = await Task.Run(() => appservice.Read(id));

            return this.Ok(entity);
        }

    }
}
