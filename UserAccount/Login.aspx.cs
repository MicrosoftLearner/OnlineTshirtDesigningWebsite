using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccount_Login : System.Web.UI.Page
{
    Customer cust;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Disable the login button from Header
        ((this.Master.FindControl("CustomHeader") as UserControl).FindControl("ButtonLogin") as Button).Visible = false;
        
    }


    protected void ButtonLoginModal_Click(object sender, EventArgs e)
    {
        //If page controls aren't valid 
        //Dont proceed
        if (!Page.IsValid) return;

        //Initialize the Customer Obj
        cust = new Customer();

        cust.objSelection = SelectionChoice.Customer;

        //Set the text values in properties
        cust.EmailId = TextBoxUserEmailModalLogin.Text;

        cust.GetPwd = TextBoxUserPwd.Text;


        if (cust.Login())
            Response.Redirect("~/Home.aspx");

        else Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Enter right Creditional OR Click Sign Up', 'Error')", true);

    }

    protected void ButtonUserSignUp_Click(object sender, EventArgs e)
    {
       // if page is not valid dont proceed below code
        if (!Page.IsValid) return;


        //To generate random numbers for HomeBaneerImgId column
        DateTime dTime = DateTime.Now;

        RequiredFieldValidator validatorEmail = (RequiredFieldValidator)(this.Page.FindControl("ValidatorEmailSignUp"));

        Label lblError = (Label)(this.Page.FindControl("LblError"));

       //Initialize the customer Obj
        cust = new Customer();

        //Set Unique id to customer
        cust.MyId = dTime.Millisecond;

        cust.CustFirstName = TBoxFirstName.Text.Trim();

        cust.CustLastName = TBoxLastName.Text.Trim();

        cust.GetPwd = TextBoxUserSignUpPwd.Text.Trim();

        cust.CustMobNo = Convert.ToInt32(TextBoxUserSignUpMobNo.Text.Trim());

        cust.EmailId = TextBoxUserSignUpEmail.Text.Trim();

        cust.CustImg = null;

        //Pass the validatorEmail and lblError Obj Reference to the class method SignUp()
            if(cust.SignUp())
            Response.Redirect("~/Home.aspx");

        else Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Email id is already in use ', 'Error')", true);

    }
}