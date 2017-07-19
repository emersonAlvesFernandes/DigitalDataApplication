using DigitalData.AppService;
using DigitalData.Domain.Entities.SubItem.Contracts;
using DigitalData.WebApiStarter.Models.Entities.SubItem;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
{
    [RoutePrefix("api/subitems")]
    public class SubItemController : ApiController
    {
        private readonly ISubItemAppService _appService;
        
        public SubItemController(ISubItemAppService appService)
        {
            this._appService = appService;
        }

        public SubItemController()
        {
            this._appService = new SubItemAppService();
        }

        [HttpPost]
        [Route("{itemId}")]
        [ResponseType(typeof(SubItemSummaryRead))]
        public async Task<IHttpActionResult> CreateAsync([FromUri]int itemId, [FromBody]SubItemCreate subitemCreate)
        {
            var UserId = 1;

            var validationResults = new SubItemCreateValidator().Validate(subitemCreate);
            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var subItemEntity = subitemCreate.ToEntity();

            var createdSubItem = await Task.Run(() => _appService.Create(itemId, subItemEntity, UserId));

            var itemRead = new SubItemSummaryRead()
                .ToSubItemRead(createdSubItem);

            return this.Ok(itemRead);
        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(SubItemSummaryRead))]
        public async Task<IHttpActionResult> UpdateAsync([FromBody]SubItemSummaryRead subitemUpdate)
        {
            //var user = UserId;
            var user = 1;

            var validationResults = new SubItemSummaryReadValidator().Validate(subitemUpdate);
            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var subItemEntity = subitemUpdate.ToEntity();

            var createdSubItem = await Task.Run(() => _appService.Update(subItemEntity, user));

            var itemRead = new SubItemSummaryRead()
                .ToSubItemRead(createdSubItem);

            return this.Ok(itemRead);
        }

        [HttpGet]
        [Route("{itemId}")]
        [ResponseType(typeof(IEnumerable<SubItemSummaryRead>))]
        public async Task<IHttpActionResult> GetByItemIdAsync([FromUri] int itemId)
        {
            var collection = await Task.Run(()=> _appService.GetByItemId(itemId));

            var itemReadCollection = new SubItemSummaryRead()
                .ToSubItemReadCollection(collection);

            return this.Ok(itemReadCollection);
        }

        /// <summary>
        ///     DEPRECATED
        ///     Returns SubItens With Plannings
        /// </summary>
        /// <remarks>
        ///     Use this on click of item line
        /// </remarks>
        /// <param name="companyId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{companyId}/{itemId}/plannings")]
        [ResponseType(typeof(IEnumerable<SubItemCompleteRead>))]
        public async Task<IHttpActionResult> GetByItemIdWithScoresAsync([FromUri] int companyId, [FromUri] int itemId)
        {
            var collection = await Task.Run(() => _appService.GetByItemIdWithScores(companyId, itemId));

            var itemReadCollection = new SubItemCompleteRead()
                .ToSubItemCompleteReadCollection(collection);

            return this.Ok(itemReadCollection);
        }

        [HttpGet]
        [Route("{companyId}/{itemId}")]
        [ResponseType(typeof(IEnumerable<SubItemCompleteRead>))]
        public async Task<IHttpActionResult> GetByCompanyAndItemIAsync([FromUri] int companyId, [FromUri] int itemId)
        {
            var collection = await Task.Run(() => _appService.GetByItemIdWithoutScores(companyId, itemId));

            var itemReadCollection = new SubItemCompleteRead()
                .ToSubItemCompleteReadCollection(collection);

            return this.Ok(itemReadCollection);
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteAsync([FromUri] int id)
        {
            //var userId = UserId;
            var userId = 1;

            var isDeleted = await Task.Run(() => _appService.Delete(id, userId));

            return this.Ok(isDeleted);
        }

        [HttpPost]
        [Route("relate/{companyId}/{itemId}/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> RelateAsync([FromUri]int companyId, [FromUri]int itemId, [FromUri]int id)
        {
            //var user = UserId;
            var user = 1;

            var isRelated = await Task.Run(()=> _appService.Relate(companyId, itemId, id, user));

            return this.Ok(isRelated);
        }

        [HttpPut]
        [Route("unrelate/{companyId}/{itemId}/{id}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UnrelateAsync([FromUri]int companyId, [FromUri]int itemId, [FromUri]int id)
        {
            //var userId = UserId;
            var userId = 1;

            var isUnrelated = await Task.Run(() => _appService.UnRelate(companyId, itemId, id,  userId));

            return this.Ok(isUnrelated);
        }
    }
}
