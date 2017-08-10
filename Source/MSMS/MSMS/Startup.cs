using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSMS.Startup))]
namespace MSMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
