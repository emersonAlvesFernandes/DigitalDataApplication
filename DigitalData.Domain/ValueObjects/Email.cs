using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.ValueObjects
{
    //TODO: utilizar a classe como um objeto de valor
    public class Email
    {
        public string Address { get; set; }
        
        public bool Validate()
        {
            return true;
        }
    }
}
