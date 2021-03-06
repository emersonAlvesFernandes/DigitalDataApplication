﻿
using DigitalData.AppService;
using DigitalData.AppService.Contracts;
using DigitalData.Domain.Entities.Default;
using DigitalData.WebApiStarter.Models;
using FastMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
{
    [RoutePrefix("api/DefaultData")]
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
        [ResponseType(typeof(DefaultData))]
        public async Task<IHttpActionResult> CreateAsync([FromBody] DefaultDataCreate defaultCreate,
        [FromUri] int campaignId)
        {

            var defaultCreateEntity =
                TypeAdapter.Adapt<DefaultDataCreate, DefaultData>(defaultCreate);

            var entityCreated = await Task.Run(() => appservice.Create(defaultCreateEntity));

            return this.Ok(entityCreated);
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

        [HttpPost]
        [Route("import")]
        [ResponseType(typeof(DefaultData))]
        public async Task<IHttpActionResult> ImportAsync([FromBody] DefaultDataExcelCreate defaultDataExcelCreate,
        [FromUri] int campaignId)
        {
            var defaultDataEntity =
                TypeAdapter.Adapt<DefaultDataExcelCreate, DefaultDataExcel>(defaultDataExcelCreate);

            var entityCollection = await Task.Run(() => appservice
                .ImportExcelFile(defaultDataEntity));

            return this.Ok(entityCollection);
        }

    }
}
