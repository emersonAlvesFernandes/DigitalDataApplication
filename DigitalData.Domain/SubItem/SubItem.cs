using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.SubItem
{
    public class SubItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Planning.Planning MonthlyPlanning { get; set; }

        public double TotalBudgetedValue { get; set; }

        public double TotalProjectedValue { get; set; }
    }
}
