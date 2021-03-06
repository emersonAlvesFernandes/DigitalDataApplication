﻿using System;
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

    public class InvalidRoleException : ApiException
    {
        private static string message = "perfil inválido";

        public InvalidRoleException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
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

    public class InvalidCompanyAddressException : ApiException
    {
        private static string message = "endereço da empresa inválido";

        public InvalidCompanyAddressException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class InvalidCompanyAddressRelationException : ApiException
    {
        private static string message = "endereço não relacionado a empresa informada";

        public InvalidCompanyAddressRelationException() : base(message)
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
        private static string message = "Apenas itens com desdobramento podem conter subitens";

        public AtomicItemException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class InvalidDeleteItemException : ApiException
    {        
        private static string message = "Item não pode ser deletado pois já está relacionado a alguma empresa";

        public InvalidDeleteItemException() : base(message)
        {
            this.statusCode = HttpStatusCode.BadRequest;
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

    public class ExistingUserException : ApiException
    {        
        private static string message = "Usuário existente";

        public ExistingUserException() : base(HttpStatusCode.BadRequest, "existing.user"){ }

        //public ExistingUserException() : base(message)
        //{
        //    base.statusCode = HttpStatusCode.BadRequest;
        //}
    }

    public class NotExistingUserException : ApiException
    {
        private static string message = "Usuário inexistente";

        public NotExistingUserException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }

    public class InvalidUserOrPAsswordException : ApiException
    {
        //private static string message = "Usuário ou Senha inválidos";
        private static string message = "invalid.user.or.password";

        public InvalidUserOrPAsswordException() : base(message)
        {
            base.statusCode = HttpStatusCode.BadRequest;
        }
    }
}
