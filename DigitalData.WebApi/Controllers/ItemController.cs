using DigitalData.AppService;
using DigitalData.Domain.Entities.Item;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.WebApi.Models.Entities.Item;
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
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        private IItemAppService _appService;

        public ItemController()
        {
            _appService = new ItemAppService();
        }

        public ItemController(IItemAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(ItemRead))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]ItemCreate itemCreate)
        {
            var validationResults = new ItemCreateValidator().Validate(itemCreate);

            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));
            
            var itemEntity = TypeAdapter.Adapt<ItemCreate, ItemEntity>(itemCreate);

            var createdItem = _appService.Create(itemEntity);

            var itemRead = TypeAdapter.Adapt<ItemEntity, ItemRead>(createdItem);

            return this.Ok(itemRead);
        }
    }
}
