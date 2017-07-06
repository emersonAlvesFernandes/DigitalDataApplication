using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem.Contracts
{
    public interface ISubItemAppService
    {
        SubItemEntity Create(int itemId, SubItemEntity subItem, int userId);
    }
}
