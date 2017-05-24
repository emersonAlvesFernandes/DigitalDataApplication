using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Company
{
    public interface ICompany
    {
        Company Create(Company company);

        IEnumerable<Company> Get();

        Company Get(int id);

        Company Update(Company company);

        bool Delete(int id);
    }
}
