using DigitalData.SqlRepository.Entities.User;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DigitalData.WebApiStarter.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //valida token no cache
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = context.UserName;
                var password = context.Password;

                var userEntity = new UserRepository().GetByUsername(user);
                var isValid = userEntity.Validate(password);
                
                if (userEntity == null || isValid == false)
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                    return;
                }

                #region manual
                //if (user != "R2088" || password != "xpto")
                //{
                //    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                //    return;
                //}
                #endregion

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                var userFullName = string.Format("{0} {1}", userEntity.FirstName, userEntity.LastName);

                identity.AddClaim(new Claim(ClaimTypes.Name, userFullName));
                identity.AddClaim(new Claim("CompanyId", userEntity.CompanyId.ToString()));
                identity.AddClaim(new Claim("UserId", userEntity.Id.ToString()));

                var userRole = new RoleRepository().GetByUser(userEntity.Id);

                if(userRole == null)
                {
                    context.SetError("invalid_grant", "Falha ao obter permissões do usuário");
                    return;
                }


                var roles = new List<string>();

                //roles.Add("Admin");
                roles.Add(userRole.Description);
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }


                var principal = new GenericPrincipal(identity, roles.ToArray());

                //Se não executar a linha abaixo, não é possível obter os dados no controller
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Falha ao Autenticar");
            }
        }
    }
}