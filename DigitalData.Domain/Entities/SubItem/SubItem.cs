using DigitalData.Domain.Entities.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.SubItem
{
    public class SubItemEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<PlanningEntity> MonthPlanning { get; set; }

        public PlanningEntity TotalYearPlanning { get; set; }
    }
}
