using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item.Contracts
{
    public interface IItemService
    {
        ItemEntity Create(ItemEntity item); 
        
        IEnumerable<ItemEntity> GetAll();
        
        ItemEntity GetById(int id);

        ItemEntity Update(ItemEntity item);

        bool Delete(int id);


        IEnumerable<ItemEntity> GetByCompanyId(int companyId);

        ItemEntity Relate(int companyId, int id);

        bool UnRelate(int companyId, int id);
    }
}
