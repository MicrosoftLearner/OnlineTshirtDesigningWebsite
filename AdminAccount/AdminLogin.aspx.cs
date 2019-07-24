using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    HttpCookie cookie;

    Admin adm;

    private string url = "AdminOrder.aspx?";

    protected void Page_Load(object sender, EventArgs e)
    {
        adm = new Admin();
        // if this page is being viewed 1st time 
        if (!this.IsPostBack)
        {
            Master.HeaderVisibility = false;

            Master.FooterVisibility = false;

            Master.AdminHeaderVisibility = true;

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
            //Set Id & name
            adm.MyId = Convert.ToInt32(cookie["AdminId"]);

            adm.Name = cookie["AdminName"];

            url += "Id=" + adm.MyId + "&";
            url += "Name=" + adm.Name;

            Response.Redirect(url);
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


        //call login method 
        if (adm.Login())
        {
            url += "Id=" + adm.MyId + "&";
            url += "Name=" + adm.Name;

            Response.Redirect(url);
        }

        else Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Enter right Creditional', 'Error')", true);
    }
}