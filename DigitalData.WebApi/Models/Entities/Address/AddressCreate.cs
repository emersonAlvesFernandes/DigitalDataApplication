using DigitalData.Domain.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Address
{
    public class AddressCreate
    {        
        public string Address { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Zipcode { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }


        public AddressEntity ToEntity()
        {
            var a = new AddressEntity(0, Address, Number, Complement, Zipcode, Neighborhood, City, State);
            return a;
        }
    }
}