using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem.Contracts
{
    public interface ISubItemService
    {
        SubItemEntity Create(int itemId, SubItemEntity subItem, int username);

        SubItemEntity GetById(int id);
        
        IEnumerable<SubItemEntity> GetByItemId(int itemId);

        IEnumerable<SubItemEntity> GetByItemIdWithScores(int companyId, int itemId);

        bool Delete(int id, int userId);

        bool Relate(int companyId, int itemId, int id, int userId);        

        bool UnRelate(int companyId, int itemid, int id, int userId);
    }
}
