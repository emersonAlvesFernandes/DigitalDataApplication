using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item.Contracts
{
    public interface IItemRepository
    {
        Item Create(Item item);

        IEnumerable<Item> GetAll();

        Item GetById(int id);

        Item Update(Item item);

        bool Delete(int id);


        IEnumerable<Item> GetByCompanyId(int companyId);

        Item Relate(int companyId, int id);

        bool UnRelate(int companyId, int id);
    }
}
