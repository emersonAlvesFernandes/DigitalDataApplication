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
                
    }
}