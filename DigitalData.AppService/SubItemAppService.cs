using DigitalData.Domain.Entities.SubItem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.SubItem;
using DigitalData.Domain.Entities.Item.Contracts;

namespace DigitalData.AppService
{
    public class SubItemAppService : ISubItemAppService
    {
        private readonly ISubItemService _subItemService;
        private readonly IItemService _itemService;

        
        public SubItemAppService(ISubItemService subItemService, IItemService itemService)
        {
            this._subItemService = subItemService;
            this._itemService = itemService;
        }

        public SubItemEntity Create(int itemId, SubItemEntity subItem, int userId)
        {
            var item = _itemService.GetById(itemId);

            if (item == null)
                throw new Exception("invelida.id");

            return _subItemService.Create(itemId, subItem, userId);
        }
    }
}
