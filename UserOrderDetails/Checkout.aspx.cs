using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserOrderDetails_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            ButtonOrder.Enabled = false;
            ButtonDtls.Enabled = false;
            ButtonPayment.Enabled = false;
        }
    }

    protected void RegValidEmail_Init(object sender, EventArgs e)
    {
        RegValidEmail.Attributes.Add("data-toggle", "popover");
        RegValidEmail.Attributes.Add("data-content", "popover");

    }

    protected void ButtonUserLogIn_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false) return;
        Label1.Text = "Click executed";
        ButtonOrder.Enabled = true;
        ButtonDtls.Enabled = true;
        ButtonPayment.Enabled = true;
        ButtonLogin.CssClass = "btn btn--list";
        ButtonOrder.CssClass = "btn btn--list btn--brownActive";

        MultiViewCheckout.ActiveViewIndex = 1;

    }

    protected void ButtonSignUpForm_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false || CheckboxDataAgree.Checked == false) return;
        LabelAggreeMsg.Text = "click executed";
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        MultiViewCheckout.ActiveViewIndex = 0;
    }

    protected void ButtonOrder_Click(object sender, EventArgs e)
    {
        ButtonLogin.CssClass = "btn btn--list";
        ButtonOrder.CssClass = "btn btn--list btn--brownActive";

        ButtonDtls.CssClass = "btn btn--list";
        ButtonPayment.CssClass = "btn btn--list";

        MultiViewCheckout.ActiveViewIndex = 1;

    }

    protected void ButtonDtls_Click(object sender, EventArgs e)
    {
        ButtonLogin.CssClass = "btn btn--list";
        ButtonOrder.CssClass = "btn btn--list";
        ButtonPayment.CssClass = "btn btn--list";

        ButtonDtls.CssClass = "btn btn--list btn--brownActive";
        MultiViewCheckout.ActiveViewIndex = 2;

    }

    protected void ButtonPayment_Click(object sender, EventArgs e)
    {
        ButtonPayment.Enabled = true;

        ButtonLogin.CssClass = "btn btn--list";
        ButtonOrder.CssClass = "btn btn--list";
        ButtonDtls.CssClass = "btn btn--list";

        ButtonPayment.CssClass = "btn btn--list btn--brownActive";
        MultiViewCheckout.ActiveViewIndex = 3;

    }
}