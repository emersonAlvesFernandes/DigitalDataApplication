using DigitalData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace DigitalData.WebApiStarter.Controllers
{
    public class BaseController : ApiController
    {
        private Microsoft.Owin.IOwinContext Context
        {
            get
            {
                return HttpContext.Current.Request.GetOwinContext();
            }

            set { }
        }

        private IEnumerable<Claim> Claims
        {
            get
            {
                var User = Context.Authentication.User;
                return User.Claims;
            }

            set { }
        }

        public int UserId
        {
            get
            {
                var value = Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToInt32();
                if (value == null)
                    return 1;
                return value;
            }
            private set{}
        }

        public int CompanyId { get { return Claims.FirstOrDefault(x => x.Type == "CompanyId").Value.ToInt32(); } private set {} }

        //public string Name { get { return Claims; } private set { } }



        //public string GetUserId()
        //{
        //    var context = HttpContext.Current.Request.GetOwinContext();
        //    var User = context.Authentication.User;
        //    var claims = User.Claims;
        //    var claim = claims.FirstOrDefault(x => x.Type == "UserId");
        //    var userValue = claim.Value.ToInt32();
        //}
    }
}
