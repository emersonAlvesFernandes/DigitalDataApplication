using DigitalData.Domain.Entities.Address;
using DigitalData.Domain.Entities.Item;
using DigitalData.Domain.Entities.User;
using System;
using System.Collections.Generic;

namespace DigitalData.Domain.Entities.Company
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {

        }

        public CompanyEntity( 
            int id, 
            string name, 
            string cnpj,
            string website, 
            string email, 
            bool isActive,
            DateTime creationDate,
            DateTime lastUpdate)
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

        public CompanyEntity(
            int id,
            string name,
            string cnpj,
            string website,
            string email,
            bool isActive)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            WebSite = website;
            Email = email;
            IsActive = isActive;
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }

        public CompanyEntity(
            int id,
            CompanyEntity ce)
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

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Cnpj { get; private set; }

        public byte[] Logo { get; private set; }

        public string WebSite { get; private set; }

        public string Email { get; private set; }

        public AddressEntity Address { get; set; }

        public ClientUser Client { get;  set; }        

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdate { get;  set; }

        public bool IsActive { get; private set; }

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
