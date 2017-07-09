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

        public ClientUser Client { get;  set; }

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdate { get;  set; }

        
        public CompanyEntity()
        {

        }

        public CompanyEntity(int id, string name, string cnpj, string website, string email, bool isActive, DateTime creationDate, DateTime lastUpdate)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            WebSite = website;
            Email = email;
            IsActive = isActive;
            CreationDate = creationDate;
            LastUpdate = lastUpdate;
        }

        public CompanyEntity(int id, string name, string cnpj, string website, string email, bool isActive, AddressEntity address)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            WebSite = website;
            Email = email;
            IsActive = isActive;
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            Address = address;
        }

        public CompanyEntity(int id, CompanyEntity ce)
        {
            Id = id;
            Name = ce.Name;
            Cnpj = ce.Cnpj;
            WebSite = ce.WebSite;
            Email = ce.Email;
            IsActive = ce.IsActive;
            CreationDate = ce.CreationDate;
            LastUpdate = ce.LastUpdate;
        }

        public void SetCreationDate()
        {
            this.CreationDate = DateTime.Now;
        }

        public void SetLastUpdate()
        {
            this.LastUpdate = DateTime.Now;
        }
    }
}
