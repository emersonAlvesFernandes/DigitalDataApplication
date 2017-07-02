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

        public ItemEntity Create(ItemEntity item, int userId)
        {
            return _repository.Create(item, userId);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ItemEntity> GetByCompanyId(int companyId)
        {
            return _repository.GetByCompanyId(companyId);
        }

        public ItemEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Relate(int companyId, int id, int userId)
        {
            return _repository.Relate(companyId, id, userId);
        }

        public bool UnRelate(int companyId, int id)
        {
            throw new NotImplementedException();
        }

        public ItemEntity Update(ItemEntity item, int userId)
        {
            return _repository.Update(item, userId);
        }
    }
}
