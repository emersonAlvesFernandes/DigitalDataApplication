using DigitalData.Domain.Entities.SubItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.SubItem
{
    public class SubItemSummaryRead
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }


        public SubItemSummaryRead ToSubItemRead(SubItemEntity entity)
        {
            return new SubItemSummaryRead
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };            
        }

        public List<SubItemSummaryRead> ToSubItemReadCollection(IEnumerable<SubItemEntity> entityCollection)
        {
            var readCollection = new List<SubItemSummaryRead>();

            foreach(var entity in entityCollection)
            {
                var subItemRead = new SubItemSummaryRead
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };

                readCollection.Add(subItemRead);
            }
            return readCollection;
        }
    }
}