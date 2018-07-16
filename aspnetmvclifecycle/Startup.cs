using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspnetmvclifecycle.Startup))]
namespace aspnetmvclifecycle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
