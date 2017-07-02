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
    [RoutePrefix("api/items")]
    public class ItemController : ApiController
    {
        private readonly IItemAppService _appService;

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
            var user = 1;

            var validationResults = new ItemCreateValidator().Validate(itemCreate);

            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var itemEntity = TypeAdapter.Adapt<ItemCreate, ItemEntity>(itemCreate);

            var createdItem = await Task.Run(() => _appService.Create(itemEntity, user));

            var itemRead = TypeAdapter.Adapt<ItemEntity, ItemRead>(createdItem);

            return this.Ok(itemRead);
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<ItemRead>))]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var collection = await Task.Run(()=> _appService.GetAll());
            
            var readItems = TypeAdapter.Adapt<IEnumerable<ItemEntity>, 
                IEnumerable<ItemRead>>(collection);
                        
            return this.Ok(readItems);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(ItemRead))]
        public async Task<IHttpActionResult> GetItemByIdAsync([FromUri]int id)
        {
            var item = await Task.Run(() => _appService.GetById(id));

            var readItems = TypeAdapter.Adapt<ItemEntity, ItemRead>(item);

            return this.Ok(readItems);
        }

        [HttpGet]
        [Route("company/{companyId}")]
        [ResponseType(typeof(IEnumerable<ItemRead>))]
        public async Task<IHttpActionResult> GetItemsByCompanyAsync([FromUri]int companyId)
        {
            var item = await Task.Run(() => _appService.GetByCompanyId(companyId));

            var readItems = TypeAdapter.Adapt<IEnumerable<ItemEntity>, 
                IEnumerable<ItemRead>>(item);

            return this.Ok(readItems);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(ItemRead))]
        public async Task<IHttpActionResult> UpdateAsync([FromBody]ItemCreate item, [FromUri]int id)
        {
            var userId = 1;

            var itemEntity = TypeAdapter.Adapt<ItemCreate, ItemEntity>(item);
            itemEntity.Id = id;

            var updItem = await Task.Run(() => _appService.Update(itemEntity, userId));

            var readItems = TypeAdapter.Adapt<ItemEntity, ItemRead>(updItem);

            return this.Ok(readItems);
        }

        [HttpPost]
        [Route("relate/{companyId}/{itemId}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> RelateAsync([FromUri]int companyId, [FromUri]int itemId)
        {
            var userId = 1;

            var isRelated = await Task.Run(() => _appService.Relate(companyId, itemId, userId));
            
            return this.Ok(isRelated);
        }
    }
}
