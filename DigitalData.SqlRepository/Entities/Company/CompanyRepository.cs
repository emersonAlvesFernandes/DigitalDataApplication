using DigitalData.Domain.Entities.Company.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Company;

namespace DigitalData.SqlRepository.Entities.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyEntity Create(CompanyEntity company)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public CompanyEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyEntity Update(Domain.Entities.Company.CompanyEntity company)
        {
            throw new NotImplementedException();
        }
    }
}
