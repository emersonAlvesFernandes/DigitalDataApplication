using DigitalData.Domain.Entities.Planning.Contracts;
using DigitalData.WebApi.Models.Entities.Planning;
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
    [RoutePrefix("api/planning")]
    public class PlanningController : ApiController
    {

        private readonly IPlanningAppService _app;

        public PlanningController(IPlanningAppService app)
        {
            this._app = app;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(PlanningReadCollectionDto))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]PlanningCreateCollection createDto)
        {
            var userId = 1;

            var yearDto = new PlanningCreateDtoValidator().Validate(createDto.YearPlanning);
            if(!yearDto.IsValid)
                return this.BadRequest(string.Join(" , ", yearDto.Errors));

            var monthlyPlanningEntity = createDto.GetEntityMonthlyPlanningCollection();
            
            var yearPlanningEntity = createDto.GetEntityYearPlanningCollection();

            var dictionary = await Task.Run(() => _app.Create(createDto.CompanyId, createDto.ItemId, createDto.SubItemId, monthlyPlanningEntity, yearPlanningEntity, userId));

            var readDto = new PlanningReadCollectionDto(dictionary);

            return this.Ok(readDto);
        }

        [HttpGet]
        [Route("{subItemId}")]
        [ResponseType(typeof(PlanningReadCollectionDto))]
        public async Task<IHttpActionResult> GetAllBySubItemAsync([FromBody]int subItemId)
        {

            return this.Ok();
        }

    }
}
