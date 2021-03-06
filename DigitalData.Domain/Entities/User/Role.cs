﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User
{
    public class Role
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<Functionality> Functionalities { get; set; }

        public Role(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
