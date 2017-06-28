using DigitalData.Domain.Entities.Item.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Item;
using DigitalData.SqlRepository.Entities.Item;

namespace DigitalData.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService()
        {
            this._repository = new ItemRepository();
        }
        public ItemService(IItemRepository repository)
        {
            this._repository = repository;
        }

        public ItemEntity Create(ItemEntity item)
        {
            return _repository.Create(item);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemEntity> GetByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }

        public ItemEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ItemEntity Relate(int companyId, int id)
        {
            throw new NotImplementedException();
        }

        public bool UnRelate(int companyId, int id)
        {
            throw new NotImplementedException();
        }

        public ItemEntity Update(ItemEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
