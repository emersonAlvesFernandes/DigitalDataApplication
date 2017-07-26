using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;
using DigitalData.Domain.ApiException;

namespace DigitalData.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IFunctionalityRepository _funcionalityRepository;
        

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public bool CreateRelation(int roleId, int userId)
        {
            return _roleRepository.CreateRelation(roleId, userId);
        }

        public bool DeleteRelation(int roleId, int userId)
        {
            return _roleRepository.DeleteRelation(roleId, userId);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public IEnumerable<Functionality> GetAllByRole(int roleId)
        {
            return _funcionalityRepository.GetAllByRole(roleId);
        }

        public Role GetByUser(int userId)
        {
            var role = _roleRepository.GetByUser(userId);

            role.Functionalities = _funcionalityRepository.GetAllByRole(role.Id).ToList();            

            return role;
        }

        public void Validate(int roleId)
        {
            var role = _roleRepository.GetAll().FirstOrDefault(x=> x.Id == roleId);

            if (role == null)
                throw new InvalidRoleException();
        }

        public bool UpdateRelation(int roleId, int userId)
        {
            return _roleRepository.UpdateRelation(roleId, userId);
        }
    }
}
