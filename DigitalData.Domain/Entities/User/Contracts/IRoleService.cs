using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User.Contracts
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();

        Role GetByUser(int userId);

        bool CreateRelation(int roleId, int userId);

        bool UpdateRelation(int roleId, int userId);

        bool DeleteRelation(int roleId, int userId);
    }
}
