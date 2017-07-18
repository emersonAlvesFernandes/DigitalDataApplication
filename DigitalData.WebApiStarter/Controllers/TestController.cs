using DigitalData.Domain.Entities.Company.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
{
    /// <summary>
    /// Represents test controller that should be removed.
    /// </summary>
    public class TestController : ApiController
    {
        private readonly ICompanyAppService _companyAppService;

        public TestController(ICompanyAppService companyAppService)
        {
            this._companyAppService = companyAppService;
        }

        [HttpGet, Route("tests")]
        public IHttpActionResult Get()
        {
            return Ok(new List<string> { "Test 1", "Test 2" });
        }

        [HttpGet, Route("tests/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(id * id);
        }

        [HttpGet]
        [Route("companies/")]        
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var collection = await Task.Run(() => _companyAppService.GetAll());
            
            return this.Ok(collection);
        }
    }
}
