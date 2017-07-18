using DigitalData.Domain.Entities.SubItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.IdsOnly
{
    public class SubItemId
    {
        public int Id { get; set; }
                
        public SubItemId(SubItemEntity e)
        {            
            Id = e.Id;                            
        }

    }
}