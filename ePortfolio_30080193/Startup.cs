using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ePortfolio_30080193.Startup))]
namespace ePortfolio_30080193
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
