﻿using DigitalData.Domain.Entities.Item.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.Item;
using DigitalData.Service;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.Domain.Entities.Planning.Contracts;

namespace DigitalData.AppService
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemService _itemService;
        private readonly ICompanyService _companyService;
        private readonly IPlanningService _planningService;

        public ItemAppService()
        {
            _itemService = new ItemService();
            _companyService = new CompanyService();
        }

        public ItemAppService(IItemService service, ICompanyService companyService, IPlanningService planningService)
        {
            _itemService = service;
            _companyService = companyService;
            _planningService = planningService;
        }

        public ItemEntity Create(ItemEntity item, int userId)
        {
            return _itemService.Create(item, userId);
        }

        public bool Delete(int itemId)
        {
            var companiesWithItem = _companyService.GetCompanyByItem(itemId);
            if (companiesWithItem.Count() > 0)
                throw new Exception("item.already.related.to.company");

            var item = _itemService.GetById(itemId);

            if (item == null)
                throw new Exception("invalid.id");

            return _itemService.Delete(itemId);            
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            var collection = _itemService.GetAll();

            var validCollection = collection.Where(x => x.IsActive == true).ToList();

            return validCollection;
        }

        public ItemEntity GetById(int itemId)
        {
            return _itemService.GetById(itemId);
        }

        public ItemEntity GetByIdWithMonthlyGroupPlannings(int itemId, int companyId)
        {
            var item =  _itemService.GetById(itemId);

            item.MonthPlanning = _planningService.GetItemGroupedPlannings(companyId, itemId).ToList();

            return item;
        }

        public ItemEntity Update(ItemEntity item, int userId)
        {
            var existingItem = _itemService.GetById(item.Id);

            if (existingItem == null)
                throw new Exception("invalid.item.id");

            return _itemService.Update(item, userId);
        }

        public bool Relate(int companyId, int id, int userId)
        {
            this.ValidateItemCompanyRelation(companyId, id);



            return _itemService.Relate(companyId, id, userId);
        }

        public IEnumerable<ItemEntity> GetByCompanyId(int companyId)
        {
            return _itemService.GetByCompanyId(companyId);
        }

        public IEnumerable<ItemEntity> GetByCompanyIdWithMonthlyGroupPlannings(int companyId)
        {
            var items =  _itemService.GetByCompanyId(companyId);
            foreach(var i in items)
            {
                i.MonthPlanning = _planningService.GetItemGroupedPlannings(companyId, companyId).ToList();
            }
            return items;
        }

        public bool Unrelate(int companyId, int id, int userId)
        {
            this.ValidateItemCompanyUnRelation(companyId, id);

            var companyItems = _itemService.GetByCompanyId(companyId);

            var containItem = companyItems
                .FirstOrDefault(x => x.Id == id);
            if (containItem == null)
                throw new Exception("relation.does.not.exists");


            return _itemService.Unrelate(companyId, id, userId);
        }

        private void ValidateItemCompanyRelation(int companyId, int id)
        {
            var item = _itemService.GetById(id);
            if (item == null)
                throw new Exception("invalid.item.id");

            var company = _companyService.GetById(companyId);
            if (company == null)
                throw new Exception("invalid.company.id");

            var companyItems = _itemService.GetByCompanyId(companyId);
            var containItem = companyItems.FirstOrDefault(x => x.Id == id);
            if (containItem != null)
                throw new Exception("relation.already.exists");
        }

        private void ValidateItemCompanyUnRelation(int companyId, int id)
        {
            var item = _itemService.GetById(id);
            if (item == null)
                throw new Exception("invalid.item.id");

            var company = _companyService.GetById(companyId);
            if (company == null)
                throw new Exception("invalid.company.id");

            var companyItems = _itemService.GetByCompanyId(companyId);
            var containItem = companyItems.FirstOrDefault(x => x.Id == id);
            if (containItem == null)
                throw new Exception("relation.does.not.exists");
        }

        public IEnumerable<ItemEntity> GetAvailableItens(int companyId)
        {
            var allItems = _itemService.GetAll();
            var companyItems = _itemService.GetByCompanyId(companyId);
            var availableItems = allItems.Except(companyItems).ToList();
            return availableItems;
        }



    }
}
