using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class UserControl_Header : System.Web.UI.UserControl
{
    HttpCookie cookie;

    Customer cust;

    protected void Page_Load(object sender, EventArgs e)
    {
        // If this page is being viewd 1st time 
        if (!this.IsPostBack)
        {
            //Check for cookie 
       //     CheckForCookie();
        }

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        //ButtonLogin.Attributes.Add("data-toggle", "modal");
        //ButtonLogin.Attributes.Add("data-target", "#LoginModal");

    }

    protected void HyperLinkLogout_Click(object sender, EventArgs e)
    {
        cust = new Customer();
        cust.Logout();
    }
}