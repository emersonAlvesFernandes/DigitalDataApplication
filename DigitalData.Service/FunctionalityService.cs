using DigitalData.Domain.Entities.User.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.User;

namespace DigitalData.Service
{
    public class FunctionalityService : IFuncionalityService
    {
        private readonly IFunctionalityRepository _repo;

        public FunctionalityService(IFunctionalityRepository repo)
        {
            repo = _repo;
        }

        public IEnumerable<Functionality> GetAllByRole(int roleId)
        {
            return _repo.GetAllByRole(roleId);
        }
    }
}
