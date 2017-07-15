using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;

namespace DigitalData.SqlRepository.Entities.User
{
    public class FunctionalityRepository : IFunctionalityRepository
    {        
        public IEnumerable<Functionality> GetAllByRole(int roleId)
        {
            return null;
        }
    }
}
