using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalData.Domain.Planning;
using DigitalData.Domain.SubItem;

namespace DigitalData.Domain.Item
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Desdobramento { get; set; }

        public Planning.Planning YearPlanning { get; set; }

        public double TotalBudgetedValue { get; set; }

        public double TotalProjectedValue { get; set; }

        public SubItem.SubItem SubItem { get; set; }       
    }
}
