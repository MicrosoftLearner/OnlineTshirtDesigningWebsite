using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Header : System.Web.UI.UserControl
{
    HttpCookie cookie;

    Customer cust;

    protected void Page_Load(object sender, EventArgs e)
    {

        //Check for cookie 
        CheckForCookie();
   
    }

    private void CheckForCookie()
    {
        cust = new Customer();

        // Need to check cookie is present or not 
        cookie = Request.Cookies["CustomerInfo"];

        if (cookie != null)
        {
            //Set Id 
            cust.MyId = Convert.ToInt32(cookie["CustId"]);

            //Disable the controls on header 
            ButtonLogin.Enabled = false;

            //Retrive all the customer data 
            cust.DisplayCustomerData();

            //Set the Object field's value to controls 
            NavCustInfo.Attributes.Add("class" , "show");
            HyperLinkUserName.Text = "Hi" + cust.CustFirstName;
        }
        else
        {
            NavCustInfo.Attributes.Add("class", "hidden");
            ButtonLogin.Enabled = true;
          
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        //ButtonLogin.Attributes.Add("data-toggle", "modal");
        //ButtonLogin.Attributes.Add("data-target", "#LoginModal");

    }
}