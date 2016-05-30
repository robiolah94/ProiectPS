using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgentieTorism.Startup))]
namespace AgentieTorism
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
