using DigitalData.Domain.Entities.SubItem;
using DigitalData.Domain.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.SubItem
{
    public class SubItemCompleteRead
    {
        public int Id { get; set; }

        public string Name { get;  set; }

        public string Description { get; set; }

        public List<PlanningEntity> Plannings { get; set; }
        
        public List<SubItemCompleteRead> ToSubItemCompleteReadCollection(IEnumerable<SubItemEntity> entityCollection)
        {
            var readCollection = new List<SubItemCompleteRead>();

            foreach (var entity in entityCollection)
            {
                var subItemRead = new SubItemCompleteRead
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Plannings = entity.MonthPlanning                                       
                };

                readCollection.Add(subItemRead);
            }
            return readCollection;
        }
    }
}