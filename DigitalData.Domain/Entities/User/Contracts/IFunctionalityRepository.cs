using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User.Contracts
{
    public interface IFunctionalityRepository
    {
        IEnumerable<Functionality> GetAllByRole(int roleId);
    }
}
