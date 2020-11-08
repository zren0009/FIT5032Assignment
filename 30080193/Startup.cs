using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_30080193.Startup))]
namespace _30080193
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
