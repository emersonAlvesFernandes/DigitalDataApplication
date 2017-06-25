﻿using DigitalData.WebApi.Models.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Company
{
    public class CompanyRead
    {
        public string Name { get; set; }

        public string Cnpj { get; set; }

        public byte[] Logo { get; set; }

        public string WebSite { get; set; }

        public string Email { get; set; }

        public AddressDto Address { get; set; }
    }
}