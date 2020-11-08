using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jiujitest.Startup))]
namespace jiujitest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
