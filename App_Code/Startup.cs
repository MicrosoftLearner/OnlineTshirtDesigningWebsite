using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTshirtDesigningWebsite.Startup))]
namespace OnlineTshirtDesigningWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
