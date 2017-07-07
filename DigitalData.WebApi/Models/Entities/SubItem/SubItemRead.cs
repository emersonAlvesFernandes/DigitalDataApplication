using DigitalData.Domain.Entities.SubItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.SubItem
{
    public class SubItemRead
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }


        public SubItemRead ToSubItemRead(SubItemEntity entity)
        {
            return new SubItemRead
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };            
        }

        public List<SubItemRead> ToSubItemReadCollection(IEnumerable<SubItemEntity> entityCollection)
        {
            var readCollection = new List<SubItemRead>();

            foreach(var entity in entityCollection)
            {
                var subItemRead = new SubItemRead
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