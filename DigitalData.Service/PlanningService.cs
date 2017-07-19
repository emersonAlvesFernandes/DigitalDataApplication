using DigitalData.Domain.Entities.Planning.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Planning;
using DigitalData.SqlRepository.Entities.Planning;

namespace DigitalData.Service
{
    public class PlanningService : IPlanningService
    {
        private readonly IPlanningRepository _repository;

        public PlanningService(IPlanningRepository repository)
        {
            _repository = repository;
        }

        public PlanningService()
        {
            _repository = new PlanningRepository();
        }




        public PlanningEntity CreateMonthPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int relationId, int userId)
        {
            return _repository.CreateMonthPlanning(companyId, itemId, subItemId, planning, relationId, userId);
        }

        public PlanningEntity CreateYearPlanning(int companyId, int itemId, int? subItemId, PlanningEntity planning, int relationId, int userId)
        {
            return _repository.CreateYearPlanning(companyId, itemId, subItemId, planning, relationId, userId);
        }
        
        public IEnumerable<PlanningEntity> GetSubItemPlanning(int companyId, int itemId, int subItemId)
        {
            return _repository.GetSubItemPlanning(companyId, itemId, subItemId);
        }

        public IEnumerable<PlanningEntity> GetItemPlanning(int companyId, int itemId)
        {
            return _repository.GetItemPlannings(companyId, itemId);
        }

        public IEnumerable<PlanningEntity> GetItemGroupedPlannings(int companyId, int itemId)
        {
            return _repository.GetItemGroupedPlannings(companyId, itemId);
        }

        public PlanningEntity FillDoneValue(PlanningEntity planning, int clientId)
        {
            return _repository.FillDoneValue(planning, clientId);
        }

        public PlanningEntity Update(int idPlanning, PlanningEntity planning, int adminId)
        {
            return _repository.Update(idPlanning, planning, adminId);
        }

        
    }
}
