using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;
using DigitalData.Domain.Entities.Company.Contracts;
using System.Transactions;
using DigitalData.Domain.ApiException;

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
            this.ValidateCreation(user, roleId);

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
                
        public UserEntity Update(UserEntity user)
        {
            var entity = _userService.GetByUsername(user.UserName);
            if(entity == null)
                throw new NotExistingUserException();

            GetPasswordValidatedUser(user.UserName, user.Password);

            return _userService.Update(user);
        }

        public bool UpdatePassword(string psw, string oldPsw, string userName)
        {
            var user = this.GetPasswordValidatedUser(userName, oldPsw);

            if (user == null)
                return false;

            return _userService.UpdatePassword(psw, user.Id); 
        }




        private void ValidateCreation(UserEntity user, int roleId)
        {
            _companyService.Validate(user.CompanyId);
            _roleService.Validate(roleId);

            var userName = _userService.GetByUsername(user.UserName);
            if (userName != null)
                throw new ExistingUserException();

            var userEmail = _userService.GetByEmail(user.Email);
            if (userEmail != null)
                throw new ExistingUserException();            
        }

        private UserEntity GetPasswordValidatedUser(string userName, string psw)
        {
            var user = _userService.GetByUsername(userName);

            var isValid = user.Validate(psw);
            if (isValid)
                return null;

            // TODO buscar ROLE

            return user;
        }
    }
}
