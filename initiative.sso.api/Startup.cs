using Microsoft.Owin;
using initiative.sso.api.Authentication;
using Owin;

[assembly: OwinStartup(typeof(initiative.sso.api.Startup))]
namespace initiative.sso.api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Auth.ConfigureAuth(app);
        }
    }
}