using DigitalData.Domain.Planning;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Planning
{
    public class PlanningRead
    {
        public int Id { get; set; }

        public double? DoneValue { get; set; }

        public double PlannedValue { get; set; }

        public double GreenFrom { get; set; }

        public double GreenTo { get; set; }

        public double RedFrom { get; set; }

        public double RedTo { get; set; }

        public double Budgeted { get; set; }
        
        public string StatusColor { get; set; } //TODO: criar enum

        public int Month { get; set; } //TODO: criar enum

        public int Year { get; set; }

        public PlanningRead(PlanningEntity entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                DoneValue = entity.DoneValue;
                PlannedValue = entity.PlannedValue;
                GreenFrom = entity.GreenFrom;
                GreenTo = entity.GreenTo;
                RedFrom = entity.RedFrom;
                RedTo = entity.RedTo;
                Budgeted = entity.Budgeted;
                StatusColor = entity.StatusColor;
                Month = entity.Month;
                Year = entity.Year;
            }
        }

        public PlanningRead()
        {

        }

        public PlanningEntity ToPlanningEntity()
        {
            var entity = new PlanningEntity(Id, DoneValue, PlannedValue, GreenFrom, GreenTo, RedFrom, RedTo, Budgeted, DateTime.Now, Month, Year);
            return entity;
        }

        public List<PlanningRead> ToPlanningRead(List<PlanningEntity> collection)
        {
            var returnCollection = new List<PlanningRead>();

            foreach (var c in collection)
            {
                var dto = new PlanningRead(c);
                returnCollection.Add(dto);
            }

            return returnCollection;
        }

        public IEnumerable<PlanningRead> ToPlanningRead(IEnumerable<PlanningEntity> collection)
        {
            var returnCollection = new List<PlanningRead>();

            foreach (var c in collection)
            {
                var dto = new PlanningRead(c);
                returnCollection.Add(dto);
            }

            return returnCollection;
        }
    }

    public class PlanningReadValidator : AbstractValidator<PlanningRead>
    {
        public PlanningReadValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("id obrigatório");            
        }
    }
}