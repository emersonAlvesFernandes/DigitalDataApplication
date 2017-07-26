using DigitalData.Domain.Entities.User;
using DigitalData.Domain.Entities.User.Contracts;
using DigitalData.WebApiStarter.Models.Entities.User;
using FastMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalData.WebApiStarter.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UserRead))]
        public async Task<IHttpActionResult> CreateAsync([FromBody]UserCreate userCreate)
        {
            var results = new UserCreateValidator().Validate(userCreate);
            if (!results.IsValid)
                return this.BadRequest(string.Join(" , ", results.Errors));

            var userEntity = TypeAdapter.Adapt<UserCreate, UserEntity>(userCreate);
            
            var user = _userAppService.Create(userEntity, userCreate.RoleId);

            var userRead = TypeAdapter.Adapt<UserEntity, UserRead>(user);

            return this.Ok(userRead);
        }

        [HttpGet]
        [Route("{companyId}")]
        [ResponseType(typeof(IEnumerable<UserRead>))]
        public async Task<IHttpActionResult> GetAllByCompanyAsync([FromUri]int companyId)
        {
            var collection = _userAppService.GetAllByCompany(companyId);

            var userReadCollection = TypeAdapter.Adapt<IEnumerable<UserEntity>, IEnumerable<UserRead>>(collection);

            return this.Ok(userReadCollection);
        }
    }
}
