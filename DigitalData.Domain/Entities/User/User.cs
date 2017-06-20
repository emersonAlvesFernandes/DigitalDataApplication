using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User
{
    public class User
    {
        public int Id { get; private set; }
        
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Document { get; set; }

        public string UserName { get; private set; }
        
        public string Password { get; private set; }

        public string ConfirmPassword { get; private set; }

        public DateTime RegisterDate { get; private set; }

    }
}
