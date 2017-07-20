using DigitalData.AppService;
using DigitalData.Domain.Entities.Company;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.WebApiStarter.Models.Entities.Address;
using DigitalData.WebApiStarter.Models.Entities.Company;
using DigitalData.WebApiStarter.Models.Entities.IdsOnly;
using FastMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
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
            _companyAppService = new CompanyAppService();
        }
        
        [HttpGet]
        [Route("")]                
        [Authorize]
        [ResponseType(typeof(List<CompanyRead>))]
        public async Task<IHttpActionResult> GetAllAsync()
        {            
            var collection = await Task.Run(() => _companyAppService.GetAll());

            var readCollection = new List<CompanyRead>();
            foreach (var c in collection)
            {
                var companyRead = new CompanyRead(c);
                readCollection.Add(companyRead);
            }

            return this.Ok(readCollection);
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> GetByIdAsync([FromUri] int id)
        {
            var companyEntity = await Task.Run(() => _companyAppService.GetById(id));

            if (companyEntity == null)
                return this.Ok();

            var companyRead = new CompanyRead(companyEntity);

            return this.Ok(companyRead);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CompanyRead))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]CompanyCreate company)
        {
            var validationResults = new CompanyCreateValidator().Validate(company);

            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));
            
            var addressCreate = company.Address.ToEntity();
            var companyEntity = company.ToEntity(addressCreate);
                        
            var createdCompany = await Task.Run(() => _companyAppService.Create(companyEntity));

            var companyRead = new CompanyRead(createdCompany);

            return this.Ok(companyRead);
        }
        
        [HttpPut]
        [Route("old")]
        [ResponseType(typeof(CompanySummary))]
        public async Task<IHttpActionResult> UpdateAsync([FromBody]CompanySummary company)
        {
            //var companyEntity = TypeAdapter.Adapt<CompanySummary, CompanyEntity>(company);

            var results = new CompanySummaryValidator().Validate(company);
            if (!results.IsValid)
                return this.BadRequest(string.Join(" , ", results.Errors));

            var companyEntity = company.ToEntity();            

            var updatedCompany = await Task.Run(() => _companyAppService.Update(companyEntity));

            
            var viewModel = TypeAdapter.Adapt<CompanyEntity, CompanySummary>(updatedCompany); 
            
            return this.Ok(viewModel);
        }
        
        [HttpPut]
        [Route("address/{addressId}")]
        [ResponseType(typeof(AddressSummary))]
        public async Task<IHttpActionResult> UpdateAddressAsync([FromUri] int companyId, [FromBody]AddressSummary address)
        {

            var validationResults = new AddressSummaryValidator().Validate(address);
            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var addressEntity = address.ToEntity();

            var updatedCompany = await Task.Run(() => _companyAppService.UpdateCompanyAddress(companyId, addressEntity));

            return this.Ok(updatedCompany);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(CompanyRead))]
        public async Task<IHttpActionResult> UpdateNestedAsync([FromBody]CompanyRead companyRead, [FromUri]int id)
        {

            var validationResults = new CompanyReadValidator().Validate(companyRead);

            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var nestedEntity = companyRead.ToEntity();

            var updatedCompany = await Task.Run(() => _companyAppService.UpdateNested(nestedEntity));
            
            return this.Ok(companyRead);
        }

        [HttpGet]
        [Route("composed/{id}")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> GetComposedByIdAsync([FromUri] int id)
        {
            var companyEntity = await Task.Run(() => _companyAppService.GetComposed(id));

            if (companyEntity == null)
                return this.Ok();

            //var companyRead = new CompanyRead(companyEntity);

            return this.Ok(companyEntity);
        }

        //[HttpGet]
        //[Route("relations/{id}")]
        //[ResponseType(typeof(CompanyEntity))]
        //public async Task<IHttpActionResult> GetRelationsByCompanyAsync([FromUri] int id)
        //{
        //    var companyEntity = await Task.Run(() => _companyAppService.GetAllEntitiesRelations(id));

        //    return this.Ok(companyEntity);
        //}

        [HttpGet]
        [Route("relations/{id}")]
        [ResponseType(typeof(CompanyId))]
        public async Task<IHttpActionResult> GetRelationsByCompanyIdsAsync([FromUri] int id)
        {
            var companyEntity = await Task.Run(() => _companyAppService.GetAllEntitiesRelations(id));

            if(companyEntity == null)
                return this.Ok();

            var companyVM = new CompanyId(companyEntity);

            return this.Ok(companyVM);
        }

    }
}
