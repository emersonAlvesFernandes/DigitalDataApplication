using DigitalData.Domain.Entities.Company.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Company;
using DigitalData.Domain.Entities.Address.Contracts;
using System.Transactions;

namespace DigitalData.AppService
{
    public class CompanyAppService : ICompanyAppService
    {
        private ICompanyService _companyService;
        private IAddressService _addressService;

        public CompanyEntity Create(CompanyEntity company)
        {
            using (var transaction = new TransactionScope())
            {
                var c = _companyService.Create(company);
                c.Address = _addressService.CreateCompanyAddress(c.Id, company.Address);

                transaction.Complete();
                return c;
            }
        }

        public IEnumerable<CompanyEntity> GetAll()
        {
            return _companyService.GetAll();
        }
    }
}
