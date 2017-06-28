using DigitalData.Domain.Entities.Item.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Item;
using DigitalData.Service;

namespace DigitalData.AppService
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemService _service;

        public ItemAppService()
        {
            _service = new ItemService();
        }

        public ItemAppService(IItemService service)
        {
            _service = service;
        }

        public ItemEntity Create(ItemEntity item)
        {
            return _service.Create(item);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ItemEntity Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
