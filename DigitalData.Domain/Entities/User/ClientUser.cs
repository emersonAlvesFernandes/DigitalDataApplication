using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.User
{
    public class ClientUser : User
    {
        public int Phone { get; set; }

        public int CelPhone { get; set; }
    }
}
