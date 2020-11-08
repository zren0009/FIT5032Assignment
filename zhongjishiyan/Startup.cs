using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(zhongjishiyan.Startup))]
namespace zhongjishiyan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
