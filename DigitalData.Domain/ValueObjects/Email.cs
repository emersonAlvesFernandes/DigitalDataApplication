using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; set; }

        //TODO:
        public bool Validate()
        {
            return true;
        }
    }
}
