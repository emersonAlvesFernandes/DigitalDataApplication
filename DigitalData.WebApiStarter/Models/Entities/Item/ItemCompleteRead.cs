using DigitalData.Domain.Entities.Item;
using DigitalData.WebApiStarter.Models.Entities.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Item
{
    public class ItemCompleteRead
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Desdobramento { get; set; }

        public bool IsActive { get; set; }

        public List<PlanningRead> ReadPlannings { get; set; }

        public ItemCompleteRead(ItemEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Desdobramento = entity.Desdobramento;
            IsActive = entity.IsActive;
            ReadPlannings = new PlanningRead().ToPlanningRead(entity.MonthPlanning);
        }

        public static List<ItemCompleteRead> GetCollectionCompleteRead(IEnumerable<ItemEntity> entityCollection)
        {
            var dtoCollection = new List<ItemCompleteRead>();
            foreach (var e in entityCollection)
            {
                var itemDto = new ItemCompleteRead(e);
                dtoCollection.Add(itemDto);
            }
            return dtoCollection;
        }
    }
}