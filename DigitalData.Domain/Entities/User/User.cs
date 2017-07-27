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

        public bool IsActive { get; set; }


        public UserEntity()
        {
            this.SetInitialValues();
        }

        private void SetInitialValues()
        {
            RegisterDate = DateTime.Now.Date;
            IsActive = true;
            
        }

        //Read Entity
        public UserEntity(int id, string firstName, string lastName, string email, string document, string username, string password, string phone1, string phone2, DateTime registerDate)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Document = document;
            this.UserName = username;
            //this.Password = base64Decode(password.Trim());
            this.Password = password;
            this.Phone1 = phone1;
            this.Phone2 = phone2;
            this.RegisterDate = registerDate;
        }
       
        public bool Validate(string psw)
        {
            if (Password.Equals(psw))
                return true;
            else return false;
        }

        private string Base64Encode(string sData)
        {
            try
            {
                var encData_byte = new byte[sData.Length];

                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

                var encodedData = Convert.ToBase64String(encData_byte);

                return encodedData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public string base64Decode(string sData)
        {

            var encoder = new System.Text.UTF8Encoding();

            var utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(sData);

            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

            char[] decoded_char = new char[charCount];

            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

            string result = new String(decoded_char);

            return result;
        }
    }
}
