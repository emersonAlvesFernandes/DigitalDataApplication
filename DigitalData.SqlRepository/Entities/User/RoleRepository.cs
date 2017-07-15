using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;

namespace DigitalData.SqlRepository.Entities.User
{
    public class RoleRepository : IRoleRepository
    {
        public bool CreateRelation(int roleId, int userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRelation(int roleId, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role GetByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRelation(int roleId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
