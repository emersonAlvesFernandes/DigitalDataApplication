using DigitalData.Domain.Entities.Company.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Company;
using DigitalData.SqlRepository.Entities.Company;
using DigitalData.Domain.Entities.Address.Contracts;
using DigitalData.Domain.Entities.Address;
using DigitalData.SqlRepository.Entities.Address;

namespace DigitalData.Service
{
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAddressRepository _addressRepository;

        public CompanyService()
        {
            this._companyRepository = new CompanyRepository();
            this._addressRepository = new AddressRepository();
        }

        public CompanyService(ICompanyRepository repository)
        {
            this._companyRepository = repository;
        }

        public CompanyEntity Create(CompanyEntity company)
        {                        
            return _companyRepository.Create(company);
        }
        
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyEntity> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public CompanyEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyEntity Update(CompanyEntity company)
        {
            throw new NotImplementedException();
        }
    }
}
