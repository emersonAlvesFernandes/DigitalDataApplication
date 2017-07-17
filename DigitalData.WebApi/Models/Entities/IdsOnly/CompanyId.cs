using DigitalData.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.IdsOnly
{
    public class CompanyId
    {
        public int Id { get; set; }

        public List<ItemId> Items { get; set; }

        public CompanyId(CompanyEntity ce)
        {
            Id = ce.Id;
            var collection = new List<ItemId>();

            var validItems = ce.Items.Where(x => x.IsRelated == true);

            foreach (var i in validItems)
            {
                var item = new ItemId(i);
                collection.Add(item);
            }

            Items = collection;
        }

    }
}