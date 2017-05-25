using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem
{
    public class SubItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Planning.Planning MonthPlanning { get; set; }
        //public Planning MonthlyPlanning { get; set; }
    }
}
