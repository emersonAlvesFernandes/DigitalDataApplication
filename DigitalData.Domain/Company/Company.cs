using DigitalData.Domain.User;
using DigitalData.Domain.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Company
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }

        public Item.Item Item{ get; set; }

        public ClientUser Client { get; set; }
    }
}
