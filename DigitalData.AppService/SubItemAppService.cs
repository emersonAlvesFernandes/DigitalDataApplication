using DigitalData.Domain.Entities.SubItem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Entities.SubItem;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.Domain.Entities.Planning.Contracts;
using DigitalData.Domain.Planning;
using DigitalData.Service;

namespace DigitalData.AppService
{
    public class SubItemAppService : ISubItemAppService
    {
        private readonly ISubItemService _subItemService;
        private readonly IItemService _itemService;
        private readonly ICompanyService _companyService;
        private readonly IPlanningService _planningService;


        public SubItemAppService(ISubItemService subItemService, IItemService itemService, ICompanyService companyService, IPlanningService planningService)
        {
            this._subItemService = subItemService;
            this._itemService = itemService;
            this._companyService = companyService;
            this._planningService = planningService;
        }

        public SubItemAppService()
        {
            _subItemService = new SubItemService();
            _itemService = new ItemService();
            _companyService = new CompanyService();
            _planningService = new PlanningService();
        }


        public SubItemEntity Create(int itemId, SubItemEntity subItem, int userId)
        {
            var item = _itemService.GetById(itemId);

            if (item == null)
                throw new Exception("invelida.id");

            return _subItemService.Create(itemId, subItem, userId);
        }

        public SubItemEntity Update(SubItemEntity subItem, int userId)
        {
            return _subItemService.Update(subItem, userId);
        }

        public IEnumerable<SubItemEntity> GetByItemId(int itemId)
        {
            var SubItems = _subItemService.GetByItemId(itemId);

            var validSubItems = SubItems.ToList()
                .Where(x => x.IsActive == true);                

            return validSubItems;
        }

        public bool Delete(int id, int userId)
        {
            return _subItemService.Delete(id, userId);
        }

        public bool Relate(int companyId, int itemId, int id, int userId)
        {
            this.ValidateSubItemCompanyRelation(companyId, itemId, id);

            var isRelated = _subItemService.Relate(companyId, itemId, id, userId);

            return isRelated;
        }

        public bool UnRelate(int companyId, int itemid, int id, int userId)
        {
            return _subItemService.UnRelate(companyId, itemid, id,  userId);
        }

        private void ValidateSubItemCompanyRelation(int companyId, int itemId, int id)
        {
            var company = _companyService.GetById(companyId);
            if (company == null || company.IsActive == false)
                throw new Exception("invalid.company.id");

            var item = _itemService.GetById(itemId);
            if (item == null || item.IsActive == false)
                throw new Exception("invalid.item.id");
                    
            var subitem = _subItemService.GetById(id);
            if (subitem == null || subitem.IsActive == false)
                throw new Exception("invalid.subitem.id");            
        }

        /// <summary>
        /// Returns SubItens With Plannings
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public IEnumerable<SubItemEntity> GetByItemIdWithScores(int companyId, int itemId)
        {
            var subItens = _subItemService.GetByItemId(itemId)
                .Where(x=> x.IsActive);

            
            foreach(var si in subItens)
            {                
                var plannings = _planningService.GetSubItemPlanning(companyId, itemId, si.Id);
                si.MonthPlanning = plannings.ToList();
            }

            return subItens;            
        }

        public IEnumerable<SubItemEntity> GetByItemIdWithoutScores(int companyId, int itemId)
        {
            var subItens = _subItemService.GetByItemId(itemId)
                .Where(x => x.IsActive);

            //foreach (var si in subItens)
            //{
            //    var plannings = _planningService.GetSubItemPlanning(companyId, itemId, si.Id);
            //    si.MonthPlanning = plannings.ToList();
            //}

            return subItens;
        }
    }
}
