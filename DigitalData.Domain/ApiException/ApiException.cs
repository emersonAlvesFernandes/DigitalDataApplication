using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.ApiException
{
    public class ApiException : Exception
    {
        //protected HttpStatusCode statusCode ;
        public HttpStatusCode statusCode { get; set; }

        public ApiException(HttpStatusCode statusCode, string message, Exception ex)
            : base(message, ex)
        {
            this.statusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.statusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public ApiException(string message) : base(message)
        {
            this.statusCode = HttpStatusCode.BadRequest;
        }

        public HttpStatusCode StatusCode
        {
            get { return this.statusCode; }
        }
    }
    
    public class InvalidCompanyException : ApiException
    {        
        private static string message = "empresa inválida";

        public InvalidCompanyException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class InvalidItemException : ApiException
    {
        //private static string message = "invalid.item.id";
        private static string message = "item inválido";

        public InvalidItemException() : base(message)
        {
            this.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class InvalidItemCompanyRelationException : ApiException
    {        
        //private static string message = "item.not.related.to.company";
        private static string message = "O item não está relacionado a empresa";

        public InvalidItemCompanyRelationException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class AtomicItemException : ApiException
    {        
        //private static string message = "atomic.item.cannot.have.subitems";
        private static string message = "Apenas itens com desdobramento podem ter subitens";

        public AtomicItemException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class InvalidSubItemException : ApiException
    {        
        //private static string message = "invalid.subitem.id";
        private static string message = "Subitem inválido";
        
        public InvalidSubItemException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }
}
