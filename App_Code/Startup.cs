using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

using System.Web.Http;


[assembly: OwinStartupAttribute(typeof(OnlineTshirtDesigningWebsite.Startup))]
namespace OnlineTshirtDesigningWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureAuth(app);
            
            WebApiConfig.Register(config);
            
            app.UseWebApi(config);

        }
    }
}
