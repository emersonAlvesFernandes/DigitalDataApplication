using DigitalData.Domain.Entities.Planning.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Planning;
using DigitalData.Domain.Entities.Company.Contracts;
using DigitalData.Domain.Entities.Item.Contracts;
using DigitalData.Domain.Entities.SubItem.Contracts;
using System.Transactions;

namespace DigitalData.AppService
{
    public class PlanningAppService : IPlanningAppService
    {
        private readonly ICompanyService    _companyService;
        private readonly IItemService       _itemService;
        private readonly ISubItemService    _subItemService;
        private readonly IPlanningService   _planningService;


        public PlanningAppService (ICompanyService companyService, IItemService itemService, ISubItemService subItemService, IPlanningService planningService)
        {
            _companyService = companyService;
            _itemService = itemService;
            _subItemService = subItemService;
            _planningService = planningService;
        }


        public IDictionary<PlanningEntity, List<PlanningEntity>> Create(int companyId, int itemId, int? subItemId, List<PlanningEntity> montlyPlanning, PlanningEntity yearPlanning)
        {
            this.ValidateRelation(companyId, itemId, subItemId);
            
            using (var transaction = new TransactionScope())
            {
                var monthPlanningCollection = new List<PlanningEntity>();
                foreach (var p in montlyPlanning)
                {
                    var monthPlanning = _planningService.CreateMonthPlanning(companyId, itemId, subItemId, p);
                    monthPlanningCollection.Add(monthPlanning);
                }

                var yearPlanningEntity = _planningService.CreateYearPlanning(companyId, itemId, subItemId, yearPlanning);

                var dictionaryEntity = new Dictionary<PlanningEntity, List<PlanningEntity>>();
                dictionaryEntity.Add(yearPlanningEntity, monthPlanningCollection);

                transaction.Complete();

                // Notificate client;

                return dictionaryEntity;
            }                               
        }        

        private void ValidateRelation(int companyId, int itemId, int? subItemId)
        {
            var company = _companyService.GetById(companyId);
            if (company == null)
                throw new Exception("invalid.company");

            var companyItems = _itemService.GetByCompanyId(companyId);
            var foundItem = companyItems.Where(x => x.Id == itemId);
            if (foundItem == null)
                throw new Exception("item.invalid");

            if (subItemId != null)
            {
                var itemSubitems = _subItemService.GetByItemId(itemId);
                var foundSubItem = itemSubitems.Where(x => x.Id == subItemId);
                if (foundSubItem == null)
                    throw new Exception("subitem.invalid");
            }            
        }

    }
}
