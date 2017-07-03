using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Address
{
    public class AddressEntity
    {
        public AddressEntity()
        {

        }

        public AddressEntity(int id, 
            string address, 
            string number, 
            string complement, 
            string zipcode,
            string neighborhood, 
            string city, 
            string state)
        {
            this.Id = id;
            this.Address = address;
            this.Number = number;
            this.Complement = complement;
            this.Zipcode = zipcode;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;

            //Validate
        }

        public AddressEntity(int id, AddressEntity a)
        {
            this.Id = id;
            this.Address = a.Address;
            this.Number = a.Number;
            this.Complement = a.Complement;
            this.Zipcode = a.Zipcode;
            this.Neighborhood = a.Neighborhood;
            this.City = a.City;
            this.State = a.State;

            //Validate
        }

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
