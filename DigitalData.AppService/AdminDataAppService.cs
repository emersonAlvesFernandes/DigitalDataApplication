using DigitalData.Domain.AdminData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.AppService
{
    

    public class AdminDataAppService : IAdminDataAppService
    {
        private readonly IAdminDataService _service;

        public AdminDataAppService(IAdminDataService service)
        {
            this._service = service;
        }

        public bool DeleteAllData()
        {
            return _service.DeleteAllData();
        }
    }
}
