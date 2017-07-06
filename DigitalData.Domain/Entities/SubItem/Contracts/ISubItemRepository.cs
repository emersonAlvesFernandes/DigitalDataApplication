using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem.Contracts
{
    public interface ISubItemRepository
    {
        SubItemEntity Create(int itemId, SubItemEntity subItem, int userId);

        //IEnumerable<SubItemEntity> GetAll(int itemId);

        //SubItemEntity GetById(int id);

        //SubItemEntity Update(SubItemEntity subItem, int userId);

        //bool Delete(int id, int userId);


        //SubItemEntity Relate(int companyId, int itemid, int id, int userId);

        //bool UnRelate(int companyId, int itemid, int id, int userId);
    }
}
