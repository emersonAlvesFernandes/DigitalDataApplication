using DigitalData.Domain.Entities.Address;
using DigitalData.Domain.Entities.Item;
using DigitalData.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace DigitalData.Domain.Entities.Company
{
    public class CompanyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public byte[] Logo { get; set; }

        public string WebSite { get; set; }

        public string Email { get; set; }

        public AddressEntity Address { get; set; }

        public ClientUser Client { get; set; }        

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool IsActive { get; set; }
    }
}
