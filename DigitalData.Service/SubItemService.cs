using DigitalData.Domain.Entities.SubItem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.SubItem;

namespace DigitalData.Service
{
    public class SubItemService : ISubItemService
    {
        private readonly ISubItemRepository _repository;

        public SubItemService(ISubItemRepository repository)
        {
            this._repository = repository;
        }

        public SubItemEntity Create(int itemId, SubItemEntity subItem, int username)
        {
            return _repository.Create(itemId, subItem, username);
        }
    }
}
