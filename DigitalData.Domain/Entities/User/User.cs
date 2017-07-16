using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User
{
    public class UserEntity
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get;  set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }
        
        public DateTime RegisterDate { get; set; }

        public int CompanyId { get; set; }


        public UserEntity(int id, string firstName, string lastName, string email, string document, string username, string password
            , string phone1, string phone2, DateTime registerDate)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Document = document;
            this.UserName = username;
            this.Password = password.Trim();
            this.Phone1 = phone1;
            this.Phone2 = phone2;
            this.RegisterDate = registerDate;
        }

        //TODO: encrypt and decrypt psw here

        public bool Validate(string psw)
        {
            if (Password.Equals(psw))
                return true;
            else return false;
        }

    }
}
