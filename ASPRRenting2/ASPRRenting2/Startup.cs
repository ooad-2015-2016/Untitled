using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPRRenting2.Startup))]
namespace ASPRRenting2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
