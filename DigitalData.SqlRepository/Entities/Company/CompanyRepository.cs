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
        public Domain.Entities.Company.Company Create(Domain.Entities.Company.Company company)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Company.Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Company.Company GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Company.Company Update(Domain.Entities.Company.Company company)
        {
            throw new NotImplementedException();
        }
    }
}
