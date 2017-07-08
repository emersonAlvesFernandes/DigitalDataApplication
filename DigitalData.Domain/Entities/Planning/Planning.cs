using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Planning
{
    public class PlanningEntity
    {
        public int Id { get; set; }

        public double DoneValue { get; set; }

        public double PlannedValue { get; set; }

        public double GreenFrom { get; set; }

        public double GreenTo { get; set; }

        public double RedFrom { get; set; }

        public double RedTo { get; set; }

        public double Budgeted { get; set; }

        public DateTime CreationDate { get; set; }

        public PlanningEntity(int id, double doneValue, double plannedValue, 
            double greenFrom, double greenTo, double redFrom, 
            double redTo, double budgeted, DateTime creationDate)
        {
            Id = id;
            DoneValue = doneValue;
            PlannedValue = plannedValue;
            GreenFrom = greenFrom;
            GreenTo = greenTo;
            RedFrom = redFrom;
            RedTo = redTo;
            Budgeted = budgeted;
            CreationDate = creationDate;
        }
    }
}
