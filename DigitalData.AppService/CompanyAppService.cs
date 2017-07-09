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

        public AddressEntity UpdateCompanyAddress(int companyId, AddressEntity address)
        {
            this.CheckCompanyAddressForUpdate(companyId, address.Id);
                        
            return _addressService.UpdateCompanyAddress(address);
            
        }

        public CompanyEntity UpdateNested(CompanyEntity entity)
        {
            this.CheckCompanyAddressForUpdate(entity.Id, entity.Address.Id);

            var companyUpdated = _companyService.Update(entity);
            var addressUpdated = _addressService.UpdateCompanyAddress(entity.Address);
            companyUpdated.Address = addressUpdated;

            return companyUpdated;
        }

        private void CheckCompanyAddressForUpdate(int companyId, int addressId)
        {
            var company = _companyService.GetById(companyId);
            if (company == null)
                throw new Exception("invalid.company.id");

            var address = _addressService.GetById(addressId);
            if (address == null)
                throw new Exception("invalid.company.address.id");

            var nested = _addressService.GetCompanyAddress(companyId);
            if(nested.Id != addressId)
                throw new Exception("address.not.related.to.company");
        }
    }
}
