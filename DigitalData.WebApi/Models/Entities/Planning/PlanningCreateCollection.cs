using DigitalData.Domain.Planning;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Planning
{

    public class PlanningCreateCollection
    {
        public int CompanyId { get; set; }

        public int ItemId { get; set; }

        public int SubItemId { get; set; }

        public List<PlanningCreateDto> MonthlyPlanning { get; set; }

        public PlanningCreateDto YearPlanning { get; set; }

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

        public int Month { get; set; }
        
        public PlanningEntity ToEntity()
        {
            var entity = new PlanningEntity(0, DoneValue, PlannedValue, 
                GreenFrom, GreenTo, RedFrom, RedTo, Budgeted, DateTime.Now);

            return entity;
        }        
    }

    public class PlanningCreateDtoValidator : AbstractValidator<PlanningCreateDto>
    {
        public PlanningCreateDtoValidator()
        {
            RuleFor(x => x.PlannedValue).NotEmpty().WithMessage("O valor planejado é obrigatório");

            RuleFor(x => x.Budgeted).NotEmpty().WithMessage("O valor orçado é obrigatório");            
        }
    }
}