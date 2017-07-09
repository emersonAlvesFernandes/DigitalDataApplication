using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Planning.Contracts
{
    public interface IPlanningRepository
    {
        PlanningEntity CreateMonthPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int relationId, int userId);

        PlanningEntity CreateYearPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int relationId, int userId);

        IEnumerable<PlanningEntity> GetSubItemPlanning(int companyId, int itemId, int subItemId);

        IEnumerable<PlanningEntity> GetItemPlanning(int companyId, int itemId);
        
        PlanningEntity FillDoneValue(int PlanningId, PlanningEntity planning, int clientId);

        PlanningEntity Update(int PlanningId, PlanningEntity planning, int adminId);
    }
}
