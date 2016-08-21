using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LimitlessAdmin.Startup))]
namespace LimitlessAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
