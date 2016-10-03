using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using MvcApplicationCVManagment.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcApplicationCVManagment.DBBoject;


namespace MvcApplicationCVManagment.Providers
{

    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private JOBManageRepository _repo;
        private JOBManageContext _ctx;
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            _repo = new JOBManageRepository();
            context.Validated();
            return Task.FromResult<object>(null);
            _ctx = new JOBManageContext();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            
            
            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();


                ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }

            ClaimsIdentity oAuthIdentity =  await user.GenerateUserIdentityAsync(userManager, "JWT");

  
            
            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}