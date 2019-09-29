using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
/// <summary>
///For validating user creadentials and generating access token
/// </summary>
public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
{
    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {

        context.Validated();
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        using (AdminRepository repo = new AdminRepository())
        {
            var admin = repo.ValidateAdmin(context.UserName, context.Password);

            if (admin == null)
            {
                context.SetError("Invalid grant", "Provided user name & password are incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Role, admin.AdminRole));

            identity.AddClaim(new Claim(ClaimTypes.Name, admin.AdminName));

            identity.AddClaim(new Claim("Email", admin.AdminEmailAddr));

            context.Validated(identity);

        }
    }
}