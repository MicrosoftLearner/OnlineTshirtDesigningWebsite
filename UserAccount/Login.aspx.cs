using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccount_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonLoginModal_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonUserSignUp_Click(object sender, EventArgs e)
    {
        RequiredFieldValidator validatorEmail = (RequiredFieldValidator)(this.Page.FindControl("ValidatorEmailSignUp"));

        Label lblError = (Label)(this.Page.FindControl("LblError"));

        //Pass the validatorEmail and lblError Obj Reference to the class method SignUp()
    }
}