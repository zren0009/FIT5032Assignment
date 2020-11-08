using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_123321.Startup))]
namespace _123321
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
