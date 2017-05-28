using DigitalData.Domain.Entities.Planning;
using DigitalData.Domain.Entities.SubItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Item
{
    public class ItemEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Desdobramento { get; set; }

        public List<PlanningEntity> MonthPlanning { get; set; }

        public PlanningEntity TotalYearPlanning { get; set; }
        
        public SubItemEntity SubItem { get; set; }
    }
}
