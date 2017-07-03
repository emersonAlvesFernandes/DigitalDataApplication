using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Company.Contracts
{
    public interface ICompanyRepository
    {
        CompanyEntity Create(CompanyEntity company);

        IEnumerable<CompanyEntity> GetAll();

        CompanyEntity GetById(int id);

        CompanyEntity Update(CompanyEntity company);

        bool Delete(int id);

        IEnumerable<CompanyEntity> GetCompanyByItem(int itemId);

        //TODO: Criar método para obter o logo separadamente
    }
}
