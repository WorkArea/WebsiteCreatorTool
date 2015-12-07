using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteCreatorTool.Startup))]
namespace WebsiteCreatorTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
