using DigitalData.Domain.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.IdsOnly
{
    public class ItemId
    {
        public int Id { get; set; }

        public List<SubItemId> SubItems { get; set; }

        public ItemId(ItemEntity e)
        {
            var collection = new List<SubItemId>();

            Id = e.Id;
            foreach(var si in e.SubItems)
            {
                var SubItem = new SubItemId(si);
                collection.Add(SubItem);
            }

            SubItems = collection;
        }
    }
}