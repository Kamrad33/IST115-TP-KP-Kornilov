using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP_KP_DLS.Startup))]
namespace TP_KP_DLS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
