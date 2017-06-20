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



    }
}
