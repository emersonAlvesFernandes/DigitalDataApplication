using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.Api.ViewModels
{
    public class DefaultDataCreate
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }
    }
}