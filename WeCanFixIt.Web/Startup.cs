using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeCanFixIt.Web.Startup))]
namespace WeCanFixIt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
