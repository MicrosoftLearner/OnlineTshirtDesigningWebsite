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

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //The path for generating the token
                TokenEndpointPath = new PathString("/token"),

                //Setting the token expired time 24 hours
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //MyAuthorizationServerProvider class will validate the user
                //credentials
                Provider = new MyAuthorizationServerProvider()
            };

            //Token generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //ConfigureAuth(app);
            
            //Configure Web API for self-host
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            //config.EnableCors();

            //config.Routes.MapHttpRoute(
            //     name: "DefaultAPI",
            //     routeTemplate: "api/{controller}/{id}",
            //      defaults: new { id = System.Web.Http.RouteParameter.Optional }

            //    );

            //config.Routes.MapHttpRoute("ApiWithAction", "api/{controller}/{action}/{id}", new
            //{
            //    id = System.Web.Http.RouteParameter.Optional
            //}
            //   );


            //config.Routes.MapHttpRoute("ApiWithMulipleParameters", "api/{controller}/{action}/{name}/{pwd}", 
            //    new{name = System.Web.Http.RouteParameter.Optional, pwd = System.Web.Http.RouteParameter.Optional}
            //   );

           // app.UseWebApi(config);
        }
    }
}
