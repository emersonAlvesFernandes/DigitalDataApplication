using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;
using DigitalData.Domain.Entities.Company.Contracts;
using System.Transactions;

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

        public UserEntity Create(UserEntity user, int roleId)
        {
            _companyService.Validate(user.CompanyId);
            _roleService.Validate(roleId);
            //Validar usuário já existente

            using (var transaction = new TransactionScope())
            {                
                var createdUser = _userService.Create(user);
                var companyRelation = _companyService.CreateCompanyUserRelation(createdUser.Id, createdUser.CompanyId);
                var RoleRelation = _roleService.CreateRelation(roleId, createdUser.Id);
                    
                transaction.Complete();
                return createdUser;
            }                
        }

        public IEnumerable<UserEntity> GetAllByCompany(int companyId)
        {
            _companyService.Validate(companyId);
            
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
