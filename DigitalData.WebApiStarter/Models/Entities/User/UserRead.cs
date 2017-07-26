using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models.Entities.User
{
    public class UserRead
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public string UserName { get; set; }
        
        public string Phone1 { get; set; }

        public string Phone2 { get; set; }                
    }
}