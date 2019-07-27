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
            CheckForCookie();
        }


    }

    private void CheckForCookie()
    {

        cust = new Customer();

        // Need to check cookie is present or not 
        cookie = Request.Cookies["CustomerInfo"];

        if (cookie != null)
        {
            
            //Disable the controls on Header.asax 
             (this.FindControl("ButtonLogin") as Button).Visible = false;

            //Set the Object field's value to controls 
            (this.FindControl("HyperLinkUserName") as HyperLink).Visible = true;

            //Set Id 
            cust.MyId = Convert.ToInt32(cookie["CustId"]);

            //Retrive all the customer data 
            cust.DisplayCustomerData();

            (this.FindControl("HyperLinkUserName") as HyperLink).Text = "Hi" + " " + cust.CustFirstName;
        }
        else
        {

            //Enable the controls on Header.asax 
            (this.FindControl("ButtonLogin") as Button).Visible = true;

            //Set the Object field's value to controls 
            (this.FindControl("HyperLinkUserName") as HyperLink).Visible = false;

            //NavCustInfo.Attributes.Add("class", "hidden");
            //ButtonLogin.Enabled = true;

        }

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        //ButtonLogin.Attributes.Add("data-toggle", "modal");
        //ButtonLogin.Attributes.Add("data-target", "#LoginModal");
       //s Response.Redirect("Login.aspx");

    }

    protected void HyperLinkLogout_Click(object sender, EventArgs e)
    {
        cust = new Customer();
        cust.Logout();
    }
}