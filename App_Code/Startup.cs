using Microsoft.Owin;
using System.Web.Http;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTshirtDesigningWebsite.Startup))]
namespace OnlineTshirtDesigningWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);

            //Configure Web API for self-host
            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                 name: "ProductApi",
                 routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = System.Web.Http.RouteParameter.Optional }

                );

            config.Routes.MapHttpRoute("AddToCart", "api/{controller}/{action}/{id}", new
            {
                id = System.Web.Http.RouteParameter.Optional
            }
               );

            app.UseWebApi(config);
        }
    }
}
