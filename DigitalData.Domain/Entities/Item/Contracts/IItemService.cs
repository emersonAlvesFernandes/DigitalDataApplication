using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item.Contracts
{
    public interface IItemService
    {
        ItemEntity Create(ItemEntity item, int userId); 
        
        IEnumerable<ItemEntity> GetAll();
        
        ItemEntity GetById(int id);

        ItemEntity Update(ItemEntity item, int userId);

        bool Delete(int id);


        IEnumerable<ItemEntity> GetByCompanyId(int companyId);

        bool Relate(int companyId, int id, int userId);

        bool UnRelate(int companyId, int id);
    }
}
