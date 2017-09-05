using DigitalData.Domain.Entities.Planning.Contracts;
using DigitalData.Domain.Entities.SubItem.Contracts;
using DigitalData.WebApiStarter.Models.Entities.Planning;
using DigitalData.WebApiStarter.Models.Entities.SubItem;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
{
    //[Authorize]
    [RoutePrefix("api/planning")]
    public class PlanningController : BaseController //ApiController 
    {

        private readonly IPlanningAppService _app;
        private readonly ISubItemAppService _appService;

        public PlanningController(IPlanningAppService app, ISubItemAppService appService)
        {
            this._app = app;
            this._appService = appService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(PlanningReadCollectionDto))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]PlanningCreateCollection createDto)
        {
            var userId = 1;
            //var userId = base.UserId;

            
            //if (createDto.SubItemId == 0)
            //    createDto.SubItemId = null;

            //var yearDto = new PlanningCreateDtoValidator().Validate(createDto.YearPlanning);
            //if(!yearDto.IsValid)
            //    return this.BadRequest(string.Join(" , ", yearDto.Errors));

            var monthlyPlanningEntity = createDto.GetEntityMonthlyPlanningCollection();

            //TODO: tratar se não vier preenchido
            //var yearPlanningEntity = createDto.GetEntityYearPlanningCollection();
            var yearPlanningEntity = createDto.GetCalculatedEntityYearPlanningCollection(monthlyPlanningEntity);


            var dictionary = await Task.Run(() => _app.Create(createDto.CompanyId, createDto.ItemId, createDto.SubItemId, monthlyPlanningEntity, yearPlanningEntity, userId));

            var readDto = new PlanningReadCollectionDto(dictionary);

            return this.Ok(readDto);
        }

        [HttpPut]
        [Route("fillDoneValue")]
        [ResponseType(typeof(PlanningRead))]
        public async Task<IHttpActionResult> FillDoneValueAsync([FromBody]PlanningRead updateDto)
        {
            var userId = 1;
            //var userId = base.UserId;

            var dto = new PlanningReadValidator().Validate(updateDto);
            if(!dto.IsValid)
                return this.BadRequest(string.Join(" , ", dto.Errors));

            var entity = updateDto.ToPlanningEntity();

            var updated = await Task.Run(()=> _app.FillDoneValue(entity, userId));

            return this.Ok(updated);
        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(PlanningRead))]
        public async Task<IHttpActionResult> UpdateAsync([FromBody]PlanningRead updateDto)
        {
            var clientId = 1;
            //var userId = base.UserId;


            var dto = new PlanningReadValidator().Validate(updateDto);
            if (!dto.IsValid)
                return this.BadRequest(string.Join(" , ", dto.Errors));

            var entity = updateDto.ToPlanningEntity();

            var updated = await Task.Run(() => _app.Update(updateDto.Id, entity, clientId));

            return this.Ok(updated);
        }

        /// <summary>
        /// Retorna apenas os plannings, ainda não existe funcionalidade na aplicação que precise apenas desta informação
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="itemId"></param>
        /// <param name="subItemId"></param>
        /// <returns></returns>        
        [HttpGet]
        [Route("company/{companyId}/item/{itemId}/subitem/{subItemId}")]
        [ResponseType(typeof(IEnumerable<PlanningRead>))]
        public async Task<IHttpActionResult> GetByItemIdWithPlanningsAsync([FromUri] int companyId, [FromUri] int itemId, [FromUri] int subItemId)
        {
            var collection = await Task.Run(() => _app.GetSubItemMonthlyPlannings(companyId, itemId, subItemId));
            
            var dtoCollection = new PlanningRead().ToPlanningRead(collection);
            
            return this.Ok(dtoCollection);
        }

        /// <summary>
        /// Retorna apenas os plannings, ainda não existe funcionalidade na aplicação que precise apenas desta informação
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("company/{companyId}/item/{itemId}")]
        [ResponseType(typeof(IEnumerable<PlanningRead>))]
        public async Task<IHttpActionResult> GetItemGroupPlanningsAsync([FromUri] int companyId, [FromUri] int itemId)
        {
            var collection = await Task.Run(() => _app.GetItemMonthlyGroupedPlannings(companyId, itemId));

            var dtoCollection = new PlanningRead().ToPlanningRead(collection);

            return this.Ok(dtoCollection);
        }
    }
}
