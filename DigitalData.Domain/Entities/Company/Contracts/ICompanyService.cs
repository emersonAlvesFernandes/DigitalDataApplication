using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Company.Contracts
{
    public interface ICompanyService
    {
        CompanyEntity Create(CompanyEntity company);

        IEnumerable<CompanyEntity> GetAll();

        CompanyEntity GetById(int id);

        CompanyEntity Update(CompanyEntity company);

        bool Delete(int id);

        IEnumerable<CompanyEntity> GetCompanyByItem(int itemId);
    }
}
