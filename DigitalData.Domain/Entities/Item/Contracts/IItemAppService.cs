﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item.Contracts
{
    public interface IItemAppService
    {
        ItemEntity Create(ItemEntity item, int userId);

        IEnumerable<ItemEntity> GetAll();

        ItemEntity GetById(int itemId);

        ItemEntity GetByIdWithMonthlyGroupPlannings(int itemId, int companyId);

        IEnumerable<ItemEntity> GetByCompanyId(int companyId);

        IEnumerable<ItemEntity> GetByCompanyIdWithMonthlyGroupPlannings(int companyId);

        bool Delete(int id);

        ItemEntity Update(ItemEntity item, int userId);

        bool Relate(int companyId, int id, int userId);

        bool Unrelate(int companyId, int id, int userId);

        IEnumerable<ItemEntity> GetAvailableItens(int companyId);

    }
}
