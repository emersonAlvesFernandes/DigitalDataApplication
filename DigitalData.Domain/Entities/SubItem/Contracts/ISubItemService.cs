using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem.Contracts
{
    public interface ISubItemService
    {
        SubItemEntity Create(int itemId, SubItemEntity item);


        IEnumerable<SubItemEntity> GetAll(int itemId);

        SubItemEntity GetById(int id);

        List<SubItemEntity> GetByItemId(int itemId);


        SubItemEntity Update(SubItemEntity subItem);

        bool Delete(int id);


        SubItemEntity Relate(int companyId, int itemid, int id);

        bool UnRelate(int companyId, int itemid, int id);
    }
}
