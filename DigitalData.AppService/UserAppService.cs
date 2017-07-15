using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;
using DigitalData.Domain.Entities.Company.Contracts;

namespace DigitalData.AppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IFuncionalityService _funcionalityService;
        private readonly ICompanyService _companyService;

        public UserAppService(IUserService userService, 
            IRoleService roleService, 
            IFuncionalityService funcionalityService, 
            ICompanyService companyService)
        {
            _userService = userService;
            _roleService = roleService;
            _funcionalityService = funcionalityService;
            _companyService = companyService;
        }

        public UserEntity Create(UserEntity user)
        {
            return _userService.Create(user);
        }

        public IEnumerable<UserEntity> GetAllByCompany(int companyId)
        {
            var company = _companyService.GetById(companyId);
            if (company == null)
                throw new Exception("invalid.company");

            return _userService.GetAllByCompany(companyId);
        }

        public UserEntity IsValid(string userName, string psw)
        {
            var user =  _userService.GetByUsername(userName);

            var isValid = user.Validate(psw);
            if (isValid)
                return null;
            
            // TODO buscar ROLE

            return user;
        }
        
        public UserEntity Update(UserEntity user)
        {
            var entity = _userService.GetByUsername(user.UserName);
            if(entity == null)
                throw new Exception("invalid.user");

            return _userService.Update(user);

        }

        public bool UpdatePassword(string psw, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
