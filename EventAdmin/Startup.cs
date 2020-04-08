using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventAdmin.Startup))]
namespace EventAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
