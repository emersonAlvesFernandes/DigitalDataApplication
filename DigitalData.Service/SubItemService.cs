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

        public IEnumerable<SubItemEntity> GetByItemId(int itemId)
        {
            return _repository.GetByItemId(itemId);
        }

        public IEnumerable<SubItemEntity> GetByItemIdWithScores(int companyId, int itemId)
        {
            return _repository.GetByItemIdWithScores(companyId, itemId);
        }

        public bool Delete(int id, int userId)
        {
            return _repository.Delete(id, userId);
        }

        public bool Relate(int companyId, int itemId, int id, int userId)
        {
            return _repository.Relate(companyId, itemId, id, userId);
        }

        public SubItemEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool UnRelate(int companyId, int itemid, int id, int userId)
        {
            return _repository.UnRelate(companyId, itemid, id, userId);
        }


    }
}
