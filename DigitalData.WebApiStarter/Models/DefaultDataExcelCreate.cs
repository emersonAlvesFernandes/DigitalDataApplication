using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalData.WebApiStarter.Models
{
    public class DefaultDataExcelCreate
    {
        public string Name { get; set; }

        public DateTime ImportDate { get; set; }

        public string Extention { get; set; }
        
        public string Base64ByteArray { get; set; }

        public byte[] ToBytes()
        {
            return Convert.FromBase64String(this.Base64ByteArray);
        }
    }
}