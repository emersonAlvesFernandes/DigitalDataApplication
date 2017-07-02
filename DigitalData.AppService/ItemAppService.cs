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

        public ItemEntity Create(ItemEntity item, int userId)
        {
            return _service.Create(item, userId);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            return _service.GetAll();
        }

        public ItemEntity GetById(int itemId)
        {
            return _service.GetById(itemId);
        }

        public ItemEntity Update(ItemEntity item, int id)
        {
            return _service.Update(item, id);
        }

        public bool Relate(int companyId, int id, int userId)
        {
            //do not need to check if exists because of database FK's;
            return _service.Relate(companyId, id, userId);
        }

        public IEnumerable<ItemEntity> GetByCompanyId(int companyId)
        {
            return _service.GetByCompanyId(companyId);
        }
    }
}
