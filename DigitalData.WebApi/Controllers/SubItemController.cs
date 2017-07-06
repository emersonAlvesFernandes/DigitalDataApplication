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

            var itemRead = TypeAdapter.Adapt<SubItemEntity, SubItemRead>(createdSubItem);

            return this.Ok(itemRead);
        }

    }
}
