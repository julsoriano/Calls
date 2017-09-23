using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calls.Startup))]
namespace Calls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
