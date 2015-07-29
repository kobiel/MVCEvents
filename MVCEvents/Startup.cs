using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEvents.Startup))]
namespace MVCEvents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
