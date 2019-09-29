<%@ Application Language="C#" %>
<%@ Import Namespace="OnlineTshirtDesigningWebsite" %>
<%@ Import Namespace="System.Net.Http" %>
<%@ Import Namespace="System.Web.Http" %>

<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace=" System.Web.Security" %>



<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        // For inner blogs
        RouteTable.Routes.MapPageRoute("InnerBlogsDtls", "Blogs/{BlogsId}", "~/Blogs/InnerBlogs.aspx");


       GlobalConfiguration.Configure(WebApiConfig.Register);
     

    }

</script>
