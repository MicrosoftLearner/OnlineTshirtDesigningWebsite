using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_AdminHeader : System.Web.UI.UserControl
{
    Admin adm;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

   
    protected void BtnAdminLogout_Click(object sender, EventArgs e)
    {
        adm = new Admin();

        adm.Logout();
    }
}