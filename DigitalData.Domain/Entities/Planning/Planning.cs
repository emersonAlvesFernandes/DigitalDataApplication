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

        public double? DoneValue { get; set; }

        public double PlannedValue { get; set; }

        public double GreenFrom { get; set; }

        public double GreenTo { get; set; }

        public double RedFrom { get; set; }

        public double RedTo { get; set; }

        public double Budgeted { get; set; }

        public DateTime CreationDate { get; set; }

        public string StatusColor { get; set; } //TODO: criar enum

        public int Month { get; set; }  //TODO: criar enum

        public int Year { get; set; }

        public PlanningEntity()
        {

        }

        public PlanningEntity(int id, double? doneValue, double plannedValue, 
            double greenFrom, double greenTo, double redFrom, 
            double redTo, double budgeted, DateTime creationDate, int month, int year)
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
            Month = month;
            Year = year;
            SetStatusColor();
        }

        //Usado na leitura de plannings agrupados de itens
        public PlanningEntity(int id, double doneValue, double plannedValue,
            double greenFrom, double greenTo, double redFrom,
            double redTo, double budgeted, DateTime creationDate, int month, int year, string readColor)
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
            Month = month;
            Year = year;
            StatusColor = readColor;
        }

        public void SetStatusColor()
        {
            if (DoneValue == null)
            {
                DoneValue = 0;
                StatusColor = "BRANCA";
                return;
            }

            if (DoneValue >= GreenFrom && DoneValue <= GreenTo)
            {
                StatusColor = "VERDE";
                return;
            }

            if (DoneValue >= RedFrom && DoneValue <= RedTo)
            {
                StatusColor = "VERMELHO";
                return;
            }
        }

        public PlanningEntity GetYearPlanningByMonthlyCollection(List<PlanningEntity> monthlyPlannings)
        {
            double budgeted = 0;
            double greenFrom = 0;
            double greenTo = 0;
            double redFrom = 0;
            double redTo = 0;
            double doneValue = 0;
            double plannedValue = 0;

            foreach (var p in monthlyPlannings)
            {
                budgeted += p.Budgeted;
                greenFrom += greenFrom;
                greenTo += greenTo;
                redFrom += redFrom;
                redTo += redTo;
                doneValue += doneValue;
                plannedValue += plannedValue;
            }
            var id = 0;
            var year = monthlyPlannings.Select(x => x.Year).FirstOrDefault();
            
            var planning = new PlanningEntity()
            {
                Id = id,
                Budgeted = budgeted,
                GreenFrom = greenFrom,
                GreenTo = greenTo,
                RedFrom = redFrom,
                RedTo = redTo,
                CreationDate = DateTime.Now,
                DoneValue = doneValue,
                Month = 0,
                PlannedValue = plannedValue,
                Year = year                
            };

            planning.SetStatusColor();

            return planning;

        }

    }
}
