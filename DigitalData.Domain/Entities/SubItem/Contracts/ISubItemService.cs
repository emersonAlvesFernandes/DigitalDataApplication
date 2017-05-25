using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem.Contracts
{
    public interface ISubItemService
    {
        SubItem Create(int itemId, SubItem item);

        IEnumerable<SubItem> GetAll(int itemId);

        SubItem GetById(int id);

        SubItem Update(SubItem subItem);

        bool Delete(int id);


        SubItem Relate(int companyId, int itemid, int id);

        bool UnRelate(int companyId, int itemid, int id);
    }
}
