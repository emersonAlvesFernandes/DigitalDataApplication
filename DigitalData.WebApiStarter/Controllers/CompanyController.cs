using DigitalData.AppService;
using DigitalData.Domain.Entities.Company;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.WebApiStarter.Models.Entities.Address;
using DigitalData.WebApiStarter.Models.Entities.Company;
using DigitalData.WebApiStarter.Models.Entities.IdsOnly;
using FastMapper;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
        
        //[Authorize]
        [HttpGet]
        [Route("")]                        
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

        /// <summary>
        /// Atualiza somente a entidade Empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("summary")]
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


        /// <summary>
        /// Atualiza apenas a entidade endereço
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("summary/address/{addressId}")]
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


        /// <summary>
        /// Atualiza a entidade encadeada de empresa e endereço. Alteração de dto em 21/07/2017
        /// </summary>
        /// <remarks>
        /// Alteração de dto em 21/07/2017: retirada do Id da query, está no body;
        /// </remarks>
        /// <param name="companyRead"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(CompanyRead))]
        public async Task<IHttpActionResult> UpdateNestedAsync([FromBody]CompanyRead companyRead, [FromUri] int id)
        {

            var validationResults = new CompanyReadValidator().Validate(companyRead);

            if (!validationResults.IsValid)
                return this.BadRequest(string.Join(" , ", validationResults.Errors));

            var nestedEntity = companyRead.ToEntity();

            var updatedCompany = await Task.Run(() => _companyAppService.UpdateNested(nestedEntity));
            
            return this.Ok(companyRead);
        }


        /// <summary>
        ///     Listagem de itens, subitens e planejamentos dos quais estão relacionados com a empresa 
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
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



        /// <summary>
        ///     Listagem (apenas os Ids) de itens, subitens e planejamentos dos quais estão relacionados com a empresa 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("composed/ids/{id}")]
        [ResponseType(typeof(CompanyEntity))]
        public async Task<IHttpActionResult> GetComposedIdsByIdAsync([FromUri] int id)
        {
            var companyEntity = await Task.Run(() => _companyAppService.GetComposed(id));

            if (companyEntity == null)
                return this.Ok();

            var companyVM = new CompanyId(companyEntity);

            return this.Ok(companyVM);
        }

        //[HttpGet]
        //[Route("relations/{id}")]
        //[ResponseType(typeof(CompanyEntity))]
        //public async Task<IHttpActionResult> GetRelationsByCompanyAsync([FromUri] int id)
        //{
        //    var companyEntity = await Task.Run(() => _companyAppService.GetAllEntitiesRelations(id));

        //    return this.Ok(companyEntity);
        //}

        /// <summary>
        ///     Listagem de itens e subitens já cadastrados no sistema identificados pela tag isRelated, que identifica se está relacionado com a empresa informada;
        /// </summary>
        /// <remarks>
        ///     Este serviço deve ser usado para a tela de vínculo da empresa com itens e subitens.
        ///     Ela retorna a relação da empresa com os itens e subitens existentes no sistema. cada entidade possui uma flag "isRelated",
        ///     indicando se a empresa tem vínculo.
        ///     Ao clicar na tab de vínculo, são apresentadas duas opçõs: vincular itens e desvincular items.
        ///     Ao clicar na primeira opção: chamar este serviço e deve-se exibir apenas as entidades das quais NÃO HÁ vínculo dada a empresa. Desta forma,
        ///     possibilita mandar em lote os novos vínculos;
        ///     Ao clicar na segunda opção: chamar este serviço e deve-se exibir apenas as entidades das quais HÁ VÍNCULO. Desta forma,
        ///     possibilita mandar em lote as ações de remover vínculo;               
        ///     
        /// ++ TODO: Ajustar o dto para remover propriedades não utilizadas como por exemplo os plannings
        /// </remarks>
        /// 
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("relations/{id}")]
        [ResponseType(typeof(CompanyId))]
        public async Task<IHttpActionResult> GetRelationsByCompanyIdsAsync([FromUri] int id)
        {
            var companyEntity = await Task.Run(() => _companyAppService.GetAllEntitiesRelations(id));

            if(companyEntity == null)
                return this.Ok();

            //var companyVM = new CompanyId(companyEntity);

            return this.Ok(companyEntity);
        }

    }
}
