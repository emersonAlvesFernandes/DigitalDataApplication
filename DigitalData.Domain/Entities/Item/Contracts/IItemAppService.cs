using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item.Contracts
{
    public interface IItemAppService
    {
        ItemEntity Create(ItemEntity item, int userId);

        IEnumerable<ItemEntity> GetAll();

        ItemEntity GetById(int itemId);

        IEnumerable<ItemEntity> GetByCompanyId(int companyId);

        bool Delete(int id);

        ItemEntity Update(ItemEntity item, int userId);

        bool Relate(int companyId, int id, int userId);
    }
}
