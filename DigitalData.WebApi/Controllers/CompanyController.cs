using DigitalData.AppService;
using DigitalData.Domain.Entities.Company;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.WebApi.Models.Entities.Company;
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
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            this._companyAppService = companyAppService;
        }

        public CompanyController()
        {
            this._companyAppService = new CompanyAppService();
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> CreateAsync()
        {            
            var collection = await Task.Run(() => _companyAppService.GetAll());

            return this.Ok(collection);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]CompanyCreate company)
        {

            var companyEntity =
                TypeAdapter.Adapt<CompanyCreate, CompanyEntity>(company);
            
            var collection = await Task.Run(() => _companyAppService.Create(companyEntity));            

            return this.Ok(collection);
        }
    }
}
