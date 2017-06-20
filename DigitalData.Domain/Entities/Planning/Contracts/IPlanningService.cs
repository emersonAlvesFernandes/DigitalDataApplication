using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Planning.Contracts
{
    public interface IPlanningService
    {
        PlanningEntity Create(int companyId, int itemId, int? subItemId, PlanningEntity planning);

        IEnumerable<PlanningEntity> GetSubItemPlanning(int companyId, int itemId, int subItemId);

        IEnumerable<PlanningEntity> GetItemPlanning(int companyId, int itemId);

        PlanningEntity Get(int idPlanning);

        PlanningEntity Update(int idPlanning, PlanningEntity planning);

        bool Delete(int idPlanning);
    }
}
