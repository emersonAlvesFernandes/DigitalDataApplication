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

namespace DigitalData.AppService
{
    public class PlanningAppService : IPlanningAppService
    {
        private readonly ICompanyService _companyService;
        private readonly IItemService _itemService;
        private readonly ISubItemService _subItemService;
        private readonly IPlanningService _planningService;

        public PlanningEntity Create(int companyId, int itemId, int? subItemId, List<PlanningEntity> montlyPlanning, PlanningEntity yearPlanning)
        {
            //Check if relation is valid 
            // get full nested lists 
            // find combination 
            // validate

            throw new NotImplementedException();
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
