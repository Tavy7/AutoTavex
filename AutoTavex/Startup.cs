using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoTavex.Startup))]
namespace AutoTavex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
