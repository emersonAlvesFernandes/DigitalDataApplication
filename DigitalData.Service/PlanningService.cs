using DigitalData.Domain.Entities.Planning.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Planning;

namespace DigitalData.Service
{
    public class PlanningService : IPlanningService
    {
        public PlanningEntity Create(int companyId, int itemId, int? subItemId, PlanningEntity planning)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int idPlanning)
        {
            throw new NotImplementedException();
        }

        public PlanningEntity Get(int idPlanning)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningEntity> GetItemPlanning(int companyId, int itemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanningEntity> GetSubItemPlanning(int companyId, int itemId, int subItemId)
        {
            throw new NotImplementedException();
        }

        public PlanningEntity Update(int idPlanning, PlanningEntity planning)
        {
            throw new NotImplementedException();
        }
    }
}
