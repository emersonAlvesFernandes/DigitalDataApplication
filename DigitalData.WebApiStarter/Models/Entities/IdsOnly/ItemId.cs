using DigitalData.Domain.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.IdsOnly
{
    public class ItemId
    {
        public int Id { get; set; }

        public List<SubItemId> SubItems { get; set; }

        //public ItemId(ItemEntity e)
        //{
        //    var collection = new List<SubItemId>();

        //    Id = e.Id;

        //    var validSubitems = e.SubItems.Where(x => x.IsRelated == true);

        //    foreach (var si in validSubitems)
        //    {
        //        if (si.IsRelated)
        //        {
        //            var SubItem = new SubItemId(si);
        //            collection.Add(SubItem);
        //        }
        //    }

        //    SubItems = collection;
        //}

        public ItemId(ItemEntity e)
        {
            var collection = new List<SubItemId>();

            Id = e.Id;

            var relatedSubitems = e.SubItems;

            foreach (var si in relatedSubitems)
            {                
                var SubItem = new SubItemId(si);
                collection.Add(SubItem);                
            }

            SubItems = collection;
        }
    }
}