using DigitalData.Domain.Entities.Company.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Company;
using DigitalData.Domain.Entities.Address.Contracts;
using System.Transactions;
using DigitalData.Domain.Entities.Address;
using DigitalData.Service;
using DigitalData.Domain.Entities.Item.Contracts;

namespace DigitalData.AppService
{
    public class CompanyAppService : ICompanyAppService
    {
        private ICompanyService _companyService;
        private IAddressService _addressService;        

        public CompanyAppService(ICompanyService companyService, 
            IAddressService addressService)
        {
            this._companyService = companyService;
            this._addressService = addressService;            
        }

        public CompanyAppService()
        {
            _companyService = new CompanyService();
            _addressService = new AddressService();

        }

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

        public bool Delete(int id)
        {
            return _companyService.Delete(id);            
        }

        public IEnumerable<CompanyEntity> GetAll()
        {
            var companyCollection = _companyService.GetAll();
           
            foreach(var c in companyCollection)
            {
                c.Address = _addressService.GetCompanyAddress(c.Id);                 
            }

            return companyCollection;
        }

        public CompanyEntity GetById(int id)
        {
            var company = _companyService.GetById(id);

            if (company != null)
                company.Address = _addressService.GetCompanyAddress(company.Id);

            return company;
        }

        public CompanyEntity Update(CompanyEntity company)
        {
            var ret = _companyService.Update(company);
            return ret;
        }

        public AddressEntity UpdateCompanyAddress(int addressId, AddressEntity address)
        {
            var existingAddress = _addressService.GetById(addressId);

            if (existingAddress != null)
                return _addressService.UpdateCompanyAddress(addressId, address);
            else
                throw new Exception("invalid update: address does not exists");
        }
    }
}
