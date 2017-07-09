using DigitalData.Domain.AdminData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Service
{    
    public class AdminDataService : IAdminDataService
    {
        private readonly IAdminDataRepository _repository;

        public AdminDataService(IAdminDataRepository repository)
        {
            this._repository = repository;
        }

        public bool DeleteAllData()
        {
            return _repository.DeleteAllData();
        }
    }
}
