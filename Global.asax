<%@ Application Language="C#" %>
<%@ Import Namespace="OnlineTshirtDesigningWebsite" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        // For inner blogs
        RouteTable.Routes.MapPageRoute("InnerBlogsDtls", "Blogs/{BlogsId}", "~/Blogs/InnerBlogs.aspx");
    }

</script>
