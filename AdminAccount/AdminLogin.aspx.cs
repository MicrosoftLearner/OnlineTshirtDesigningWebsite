using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_AdminLogin : System.Web.UI.Page
{
    HttpCookie cookie;

    Admin adm;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        // if this page is being viewed 1st time 
        if (!this.IsPostBack)
        {
            CheckForCookie();
        }
        //else
        //{
        //    //Restore Admin obj
        //    adm = (Admin)ViewState["CurrentAdmin"];

        //}
    }

    //protected void Page_preRender(object sender, EventArgs e)
    //{
    //    // Persist view state 
    //    ViewState["CurrentAdmin"] = adm;
    //}

    private void CheckForCookie()
    {
        // Need to check cookie is present or not 
        cookie = Request.Cookies["AdminInfo"];

        if (cookie != null)
        {
            //Set Id 
            adm.MyId = Convert.ToInt32(cookie["AdminId"]);
            Response.Redirect("AdminOrder.aspx");
        }

    }

    protected void BtnAdminLogin_Click(object sender, EventArgs e)
    {
        //Server side validation
        //if any control on the page is not valid  
        if (!Page.IsValid) return;

        // Initilaize the instance
        adm = new Admin();

        adm.objSelection = SelectionChoice.Admin;
        
        //Get email id from texbox 
        adm.EmailId = Email.Text;

        //Get pwd from Textbox
        adm.GetPwd = Password.Text;

        // Store Admin in view state 
        ViewState["CurrentAdmin"] = adm;

        //call login method 
        if (adm.Login())
            Response.Redirect("AdminOrder.aspx");

        else Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Enter right Creditional', 'Error')", true);
    }
}