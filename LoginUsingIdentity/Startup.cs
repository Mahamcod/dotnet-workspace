using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginUsingIdentity.Startup))]
namespace LoginUsingIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
