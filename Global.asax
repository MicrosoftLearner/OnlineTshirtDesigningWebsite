<%@ Application Language="C#" %>
<%@ Import Namespace="OnlineTshirtDesigningWebsite" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace=" System.Web.Security" %>
<%@ Import Namespace=" System.Web.Http" %>


<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        // For inner blogs
        RouteTable.Routes.MapPageRoute("InnerBlogsDtls", "Blogs/{BlogsId}", "~/Blogs/InnerBlogs.aspx");

        //For Api's routes
        RouteTable.Routes.MapHttpRoute(
            name: "ProductApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

      //  RouteTable.Routes.MapHttpRoute( "AddToCart","api/{controller}/{action}/{id}", new { id = System.Web.Http.RouteParameter.Optional }
            );
        }

</script>
