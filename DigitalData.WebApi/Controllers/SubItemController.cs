using DigitalData.AppService;
using DigitalData.Domain.Entities.SubItem;
using DigitalData.Domain.Entities.SubItem.Contracts;
using DigitalData.WebApi.Models.Entities.SubItem;
using FastMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApi.Controllers
{
    [RoutePrefix("api/subitems")]
    public class SubItemController : ApiController
    {
        private readonly ISubItemAppService _appService;

        //public SubItemController()
        //{
        //    this._appService = new SubItemAppService();
        //}

        public SubItemController(ISubItemAppService appService)
        {
            this._appService = appService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(SubItemRead))]
        public async Task<IHttpActionResult> CreateAsync([FromUri]int itemId, [FromBody]SubItemCreate subitemCreate)
        {
            var user = 1;

            var validationResults = new SubItemCreateValidator().Validate(subitemCreate);
            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var subItemEntity = subitemCreate.ToEntity();

            var createdSubItem = await Task.Run(() => _appService.Create(itemId, subItemEntity, user));

            var itemRead = new SubItemRead()
                .ToSubItemRead(createdSubItem);

            return this.Ok(itemRead);
        }

        [HttpGet]
        [Route("{itemId}")]
        [ResponseType(typeof(IEnumerable<SubItemRead>))]
        public async Task<IHttpActionResult> GetByItemIdAsync([FromUri] int itemId)
        {
            var collection = await Task.Run(()=> _appService.GetByItemId(itemId));

            var itemReadCollection = new SubItemRead()
                .ToSubItemReadCollection(collection);

            return this.Ok(itemReadCollection);
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteAsync([FromUri] int id)
        {
            var userId = 1;

            var isDeleted = await Task.Run(() => _appService.Delete(id, userId));

            return this.Ok(isDeleted);
        }

        [HttpPost]
        [Route("relate/{companyId}/{itemId}/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> RelateAsync([FromUri]int companyId, [FromUri]int itemId, [FromUri]int id)
        {
            var user = 1;

            var isRelated = await Task.Run(()=> _appService.Relate(companyId, itemId, id, user));

            return this.Ok(isRelated);
        }

        [HttpPut]
        [Route("unrelate/{companyId}/{itemId}/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UnrelateAsync([FromUri]int companyId, [FromUri]int itemId, [FromUri]int id)
        {
            var userId = 1;

            var isUnrelated = await Task.Run(() => _appService.UnRelate(companyId, itemId, id,  userId));

            return this.Ok(isUnrelated);
        }
    }
}
