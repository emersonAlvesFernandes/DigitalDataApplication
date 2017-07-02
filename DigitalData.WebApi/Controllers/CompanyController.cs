using DigitalData.AppService;
using DigitalData.Domain.Entities.Address;
using DigitalData.Domain.Entities.Company;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.WebApi.Models.Entities.Address;
using DigitalData.WebApi.Models.Entities.Company;
using FastMapper;
using FluentValidation.Results;
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
    [RoutePrefix("api/companies")]
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
        [ResponseType(typeof(List<CompanyRead>))]
        public async Task<IHttpActionResult> GetAllAsync()
        {            
            var collection = await Task.Run(() => _companyAppService.GetAll());

            var readCollection = new List<CompanyRead>();
            foreach (var c in collection)
            {
                var readCompany = TypeAdapter.Adapt<CompanyEntity, CompanyRead>(c);
                readCollection.Add(readCompany);
            }

            return this.Ok(readCollection);
        }

        [HttpGet]
        [Route("id")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri] int id)
        {
            var company = await Task.Run(() => _companyAppService.GetById(id));

            var companyRead = TypeAdapter.Adapt<CompanyEntity, CompanyRead>(company);

            return this.Ok(companyRead);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]CompanyCreate company)
        {
            var validationResults = new CompanyCreateValidator().Validate(company);

            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            //var companyEntity = TypeAdapter.Adapt<CompanyCreate, CompanyEntity>(company);            

            var addressCreate = company.Address.ToEntity();
            var companyEntity = company.ToEntity(addressCreate);
                        
            var createdCompany = await Task.Run(() => _companyAppService.Create(companyEntity));            

            return this.Ok(createdCompany);
        }

        [HttpPut]
        [Route("id")]
        [ResponseType(typeof(CompanySummary))]
        public async Task<IHttpActionResult> UpdateAsync([FromBody]CompanySummary company)
        {
            //var companyEntity = TypeAdapter.Adapt<CompanySummary, CompanyEntity>(company);

            var results = new CompanySummaryValidator().Validate(company);
            if (!results.IsValid)
                return this.BadRequest(string.Join(" , ", results.Errors));

            var companyEntity = company.ToEntity();            

            var updatedCompany = await Task.Run(() => _companyAppService.Update(companyEntity));

            return this.Ok(updatedCompany);
        }

        [HttpPut]
        [Route("{id}/address")]
        [ResponseType(typeof(CompanySummary))]
        public async Task<IHttpActionResult> UpdateAddressAsync([FromUri] int companyId, [FromBody]AddressCreate address)
        {            
            var addresEntity = TypeAdapter.Adapt<AddressCreate, AddressEntity>(address);
            //var results = new CompanySummaryValidator().Validate(company);
            //if (!results.IsValid)
            //    return this.BadRequest(string.Join(" , ", results.Errors));

            var updatedCompany = await Task.Run(() => _companyAppService.UpdateCompanyAddress(companyId, addresEntity));

            return this.Ok(updatedCompany);
        }

    }
}
