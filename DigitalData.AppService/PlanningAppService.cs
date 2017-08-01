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
using DigitalData.Domain.Entities.Item;
using DigitalData.Domain.ApiException;

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

        public IDictionary<PlanningEntity, List<PlanningEntity>> Create(int companyId, int itemId, int? subItemId, List<PlanningEntity> montlyPlanning, PlanningEntity yearPlanning, int userId)
        {
            this.ValidateRelation(companyId, itemId, subItemId);

            var relationId = GetRelationId(companyId, itemId, subItemId);


            using (var transaction = new TransactionScope())
            {
                var monthPlanningCollection = new List<PlanningEntity>();
                foreach (var p in montlyPlanning)
                {
                    var monthPlanning = _planningService.CreateMonthPlanning(companyId, itemId, subItemId, p, relationId, userId);
                    monthPlanningCollection.Add(monthPlanning);
                }
                
                var yearPlanningEntity = _planningService.CreateYearPlanning(companyId, itemId, subItemId, yearPlanning, relationId,  userId);

                var dictionaryEntity = new Dictionary<PlanningEntity, List<PlanningEntity>>();
                dictionaryEntity.Add(yearPlanningEntity, monthPlanningCollection);

                transaction.Complete();

                // Notificate client;

                return dictionaryEntity;
            }                               
        }        

        //TODO: Criar um serviço de validação
        private void ValidateRelation(int companyId, int itemId, int? subItemId)
        {
            var company = _companyService.GetById(companyId);
            if (company == null)                
                throw new InvalidCompanyException(); 

            var companyItems = _itemService.GetByCompanyId(companyId);
            var foundItem = companyItems.FirstOrDefault(x => x.Id == itemId);
            if (foundItem == null)                        
                throw new InvalidItemException(); 

            if (subItemId != null)
            {
                if (!foundItem.Desdobramento)
                    throw new AtomicItemException(); 

                var itemSubitems = _subItemService.GetByItemId(itemId);
                var foundSubItem = itemSubitems.Where(x => x.Id == subItemId);
                if (foundSubItem == null)
                    throw new InvalidSubItemException(); 
            }            
        }


        private int GetRelationId(int companyId, int itemId, int? subItemId)
        {
            var id = _companyService.GetCompanyItemSubItemRelationId(companyId, itemId, subItemId);
            if (id == null || id == 0)
                throw new Exception("invalid.company.item.subitem.relation");
            return id;
        }

        public PlanningEntity FillDoneValue(PlanningEntity planning, int clientId)
        {
            //var planningExists = _planningService.GetById(planning.Id);
            //if(!planningExists)
            //  throw new Exception("invalid.planning.id");

            return _planningService.FillDoneValue(planning, clientId);
        }

        public PlanningEntity Update(int PlanningId, PlanningEntity planning, int adminId)
        {
            return _planningService.Update(PlanningId, planning, adminId);
        }


        //Retorna apenas o planning, ainda não existe funcionalidade na aplicação que precise apenas desta informação
        public IEnumerable<PlanningEntity> GetSubItemMonthlyPlannings(int companyId, int itemId, int subItemId)
        {
            return _planningService.GetSubItemPlanning(companyId, itemId, subItemId);
        }

        //Retorna apenas o planning, ainda não existe funcionalidade na aplicação que precise apenas desta informação
        public IEnumerable<PlanningEntity> GetItemMonthlyGroupedPlannings(int companyId, int itemId)
        {
            var companyItems = _itemService.GetByCompanyId(companyId);
            var item = companyItems.Where(x => x.Id == itemId).FirstOrDefault();

            if(item.Desdobramento)
                return _planningService.GetItemGroupedPlannings(companyId, itemId);
            else
                return _planningService.GetItemPlanning(companyId, itemId);
        }
    }
}
