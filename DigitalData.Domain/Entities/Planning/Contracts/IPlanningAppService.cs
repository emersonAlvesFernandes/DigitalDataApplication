using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Planning.Contracts
{
    public interface IPlanningAppService
    {
        IDictionary<PlanningEntity, List<PlanningEntity>> Create(int companyId, int itemId, int? subItemId, List<PlanningEntity> montlyPlanning,
            PlanningEntity yearPlanning, int userId);

        PlanningEntity FillDoneValue(PlanningEntity planning, int clientId);

        PlanningEntity Update(int PlanningId, PlanningEntity planning, int adminId);
    }
}
