using DigitalData.AppService;
using DigitalData.Domain.Entities.Item;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.Utils;
using DigitalData.WebApi.Models.Entities.Item;
using FastMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApi.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemController : ApiController //ApiController
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
            #region
            //TODO Criar um BaseController para obter o usuário do token;

            //var context = HttpContext.Current.Request.GetOwinContext();
            //var User = context.Authentication.User;
            //var claims = User.Claims;
            //var claim = claims.FirstOrDefault(x => x.Type == "UserId");
            //var userValue = claim.Value.ToInt32();

            //var user = 1;
            #endregion

            var user = 1;

            var validationResults = new ItemCreateValidator().Validate(itemCreate);
            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var itemEntity = itemCreate.ToEntity();

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

        [HttpGet]
        [Route("available/company/{id}")]
        [ResponseType(typeof(IEnumerable<ItemRead>))]
        public async Task<IHttpActionResult> GetAvailableItemsByCompanyIdAsync([FromUri]int id)
        {
            var item = await Task.Run(() => _appService.GetAvailableItens(id));

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

            //var itemEntity = TypeAdapter.Adapt<ItemCreate, ItemEntity>(item);
            var itemEntity = itemCreate.ToEntity();

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

        [HttpPut]
        [Route("unrelate/{companyId}/{itemId}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UnrelateAsync([FromUri]int companyId, [FromUri]int itemId)
        {
            var userId = 1;

            var isRelated = await Task.Run(() => _appService.Unrelate(companyId, itemId, userId));

            return this.Ok(isRelated);
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteAsync([FromUri]int id)
        {            
            var isRelated = await Task.Run(() => _appService.Delete(id));
            return this.Ok(isRelated);
        }        
    }
}
