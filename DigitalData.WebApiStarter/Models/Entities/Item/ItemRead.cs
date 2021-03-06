﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.Item
{
    public class ItemRead
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Desdobramento { get; set; }

        public bool IsActive { get; set; }
    }
}