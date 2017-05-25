using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Company.Contracts
{
    public interface ICompanyRepository
    {
        Company Create(Company company);

        IEnumerable<Company> GetAll();

        Company GetById(int id);

        Company Update(Company company);

        bool Delete(int id);
    }
}
