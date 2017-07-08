using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Planning
{

    public class PlanningCreateCollection
    {
        List<PlanningCreateDto> MonthlyPlanning { get; set; }

        PlanningCreateDto YearPlanning { get; set; }

        public List<PlanningEntity> GetEntityMonthlyPlanningCollection()
        {
            var entityCollection = new List<PlanningEntity>();

            foreach (var m in MonthlyPlanning)
            {
                var planningdto = m.ToEntity();
                entityCollection.Add(planningdto);
            }
            return entityCollection;
        }

        public PlanningEntity GetEntityYearPlanningCollection()
        {
            var yearPlanningEntity = YearPlanning.ToEntity();
            return yearPlanningEntity;
        }
    }

    public class PlanningCreateDto
    {
        public double DoneValue { get; set; }

        public double PlannedValue { get; set; }

        public double GreenFrom { get; set; }

        public double GreenTo { get; set; }

        public double RedFrom { get; set; }

        public double RedTo { get; set; }

        public double Budgeted { get; set; }

        public PlanningEntity ToEntity()
        {
            var entity = new PlanningEntity(0, DoneValue, PlannedValue, 
                GreenFrom, GreenTo, RedFrom, RedTo, Budgeted, DateTime.Now);

            return entity;
        }
    }
}