using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApi.Models.Entities.Address
{
    public class AddressSummary
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Zipcode { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}