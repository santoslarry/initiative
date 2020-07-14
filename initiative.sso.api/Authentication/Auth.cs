using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Configuration;

namespace initiative.sso.api.Authentication
{
    public class Auth
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                    //We set SaveSigninToken to true, to be able to retrieve the bearer token using the code: ClaimsPrincipal.Current.Identities.First().BootstrapContext
                    //This flag is mandatory for this flow to work
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        SaveSigninToken = true,
                        ValidAudience = ConfigurationManager.AppSettings["ida:Audience"],
                        ValidIssuer = ConfigurationManager.AppSettings["ida:Issuer"],
                    }
                });
        }
    }
}