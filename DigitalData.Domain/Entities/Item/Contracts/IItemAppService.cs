using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item.Contracts
{
    public interface IItemAppService
    {
        ItemEntity Create(ItemEntity item);

        IEnumerable<ItemEntity> GetAll();

        bool Delete(int id);

        ItemEntity Update(int id);
    }
}
