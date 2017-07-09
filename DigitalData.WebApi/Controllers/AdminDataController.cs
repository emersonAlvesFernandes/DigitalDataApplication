using DigitalData.Domain.AdminData;
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
    [RoutePrefix("api/adminData")]
    public class AdminDataController : ApiController
    {
        private readonly IAdminDataAppService _appService;

        public AdminDataController(IAdminDataAppService appService)
        {
            this._appService = appService;
        }

        /// <summary>
        ///     Deletes all tables from database
        /// </summary>
        /// <remarks>
        ///     Deletes all tables from database
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        [ResponseType(typeof(bool))]        
        public async Task<IHttpActionResult> DeleteAsync()
        {
            var isDeleted = await Task.Run(() => _appService.DeleteAllData());
            var a = string.Format(@"{0}\bin\DigitalData.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
            return this.Ok(a);
        }
    }
}
