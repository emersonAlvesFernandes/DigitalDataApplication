using DigitalData.AppService;
using DigitalData.Domain.Entities.Item;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.WebApiStarter.Models.Entities.Item;
using DigitalData.WebApiStarter.Models.Entities.SubItem;
using FastMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
{
    //[Authorize]
    [RoutePrefix("api/items")]
    public class ItemController : ApiController //BaseController
    {
        private readonly IItemAppService _itemAppService;

        public ItemController()
        {
            _itemAppService = new ItemAppService();
        }

        public ItemController(IItemAppService appService)
        {
            _itemAppService = appService;
        }

        [Authorize]
        [HttpPost]
        [Route("")]        
        [ResponseType(typeof(ItemRead))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]ItemCreate itemCreate)
        {            
            var user = 1;
            //var user = base.UserId; //herdar de base controller

            var validationResults = new ItemCreateValidator().Validate(itemCreate);
            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var itemEntity = itemCreate.ToEntity();

            var createdItem = await Task.Run(() => _itemAppService.Create(itemEntity, user));

            var itemRead = TypeAdapter.Adapt<ItemEntity, ItemRead>(createdItem);

            return this.Ok(itemRead);
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<ItemRead>))]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var collection = await Task.Run(()=> _itemAppService.GetAll());
            
            var readItems = TypeAdapter.Adapt<IEnumerable<ItemEntity>, IEnumerable<ItemRead>>(collection);
                        
            return this.Ok(readItems);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(ItemRead))]
        public async Task<IHttpActionResult> GetItemByIdAsync([FromUri]int id)
        {
            var item = await Task.Run(() => _itemAppService.GetById(id));

            var readItems = TypeAdapter.Adapt<ItemEntity, ItemRead>(item);

            return this.Ok(readItems);
        }

        [HttpGet]
        [Route("company/{companyId}")]
        [ResponseType(typeof(IEnumerable<ItemRead>))]
        public async Task<IHttpActionResult> GetItemsByCompanyAsync([FromUri]int companyId)
        {
            var item = await Task.Run(() => _itemAppService.GetByCompanyId(companyId));

            var readItems = TypeAdapter.Adapt<IEnumerable<ItemEntity>, IEnumerable<ItemRead>>(item);

            return this.Ok(readItems);
        }

        [HttpGet]
        [Route("available/company/{id}")]
        [ResponseType(typeof(IEnumerable<ItemRead>))]
        public async Task<IHttpActionResult> GetAvailableItemsByCompanyIdAsync([FromUri]int id)
        {
            var item = await Task.Run(() => _itemAppService.GetAvailableItens(id));

            var readItems = TypeAdapter.Adapt<IEnumerable<ItemEntity>
                ,IEnumerable<ItemRead>>(item);

            return this.Ok(readItems);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(ItemRead))]
        public async Task<IHttpActionResult> UpdateAsync([FromBody]ItemCreate itemCreate, [FromUri]int id)
        {
            //It does not allow activate item by this method

            var userId = 1;
            //var userId = base.UserId;

            //var itemEntity = TypeAdapter.Adapt<ItemCreate, ItemEntity>(item);
            var itemEntity = itemCreate.ToEntity();

            itemEntity.Id = id;

            var updItem = await Task.Run(() => _itemAppService.Update(itemEntity, userId));

            var readItems = TypeAdapter.Adapt<ItemEntity, ItemRead>(updItem);

            return this.Ok(readItems);
        }

        [HttpPost]
        [Route("relate/{companyId}/{itemId}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> RelateAsync([FromUri]int companyId, [FromUri]int itemId)
        {
            var userId = 1;
            //var userId = base.UserId;

            var isRelated = await Task.Run(() => _itemAppService.Relate(companyId, itemId, userId));
            
            return this.Ok(isRelated);
        }

        [HttpPut]
        [Route("unrelate/{companyId}/{itemId}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UnrelateAsync([FromUri]int companyId, [FromUri]int itemId)
        {
            var userId = 1;
            //var userId = base.UserId;

            var isRelated = await Task.Run(() => _itemAppService.Unrelate(companyId, itemId, userId));

            return this.Ok(isRelated);
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteAsync([FromUri]int id)
        {            
            var isRelated = await Task.Run(() => _itemAppService.Delete(id));
            return this.Ok(isRelated);
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <remarks>
        /// Se o item tiver desdobramento, o id dos pontos virão zerados e não será possível editar os valores realizados.        
        /// </remarks>
        /// <param name="companyId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{companyId}/{itemId}/plannings")]
        [ResponseType(typeof(IEnumerable<ItemCompleteRead>))]
        public async Task<IHttpActionResult> GetItemGroupPlanningsAsync([FromUri] int companyId, [FromUri] int itemId)
        {
            var itemWithPlannings = await Task.Run(() => _itemAppService.GetByIdWithMonthlyGroupPlannings(itemId, companyId));

            var dto = new ItemCompleteRead(itemWithPlannings);

            return this.Ok(dto);
        }

        /// <summary>
        /// TODO: Testar fluxo
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{companyId}/plannings")]
        [ResponseType(typeof(IEnumerable<ItemCompleteRead>))]
        public async Task<IHttpActionResult> GetAllItemsGroupPlanningsAsync([FromUri] int companyId)
        {
            var collection = await Task.Run(() => _itemAppService.GetByCompanyIdWithMonthlyGroupPlannings(companyId));

            var dto = ItemCompleteRead.GetCollectionCompleteRead(collection);

            return this.Ok(collection);
        }
    }
}
