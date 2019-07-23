using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin
/// </summary>

[Serializable]
public class Admin: Shopping
{
    public override void Logout()
    {
        HttpCookie cookie;
        //Get saved cookie
        cookie = System.Web.HttpContext.Current.Request.Cookies["AdminInfo"];

        //Set cookie expire date to remove existing cookie
        cookie.Expires = DateTime.Now.AddDays(-1);

        //Set cookie to the web 
        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

        //Navigate customer to home page 
        System.Web.HttpContext.Current.Response.Redirect("AdminLogin.aspx");
    }

    public Admin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}