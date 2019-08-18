using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products_IndividualProduct : System.Web.UI.Page
{
    private string[] colorArray = new string[] { "white", "black", "gray" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Server.UrlDecode(Request.QueryString["prodId"]) != null && Server.UrlDecode(Request.QueryString["prodCode"]) != null && Server.UrlDecode(Request.QueryString["prodCat"]) != null && Server.UrlDecode(Request.QueryString["prodName"]) != null && Server.UrlDecode(Request.QueryString["prodStyle"]) != null && Server.UrlDecode(Request.QueryString["prodColor"]) != null && Server.UrlDecode(Request.QueryString["prodImg"]) != null && Server.UrlDecode(Request.QueryString["prodDesc"]) != null && Server.UrlDecode(Request.QueryString["prodPrice"]) != null)

                ShowProductInfo();

            else Response.Redirect("~/Home.aspx");
        }
    }

    private void ShowProductInfo()
    {
        ImgIndividProd.ImageUrl = Server.UrlDecode(Request.QueryString["prodImg"]);

        LblProdCode.Text = Server.UrlDecode(Request.QueryString["prodCode"]);

        LblProdName.Text = Server.UrlDecode(Request.QueryString["prodName"]);

        LblProdMrp.Text = "&#x20B9 " + Server.UrlDecode(Request.QueryString["prodPrice"]);

        LblProdDisc.Text = Server.UrlDecode(Request.QueryString["prodDesc"]);

        LblProdCat.Text = Server.UrlDecode(Request.QueryString["prodCat"]);

        LblProdColorName.Text = Server.UrlDecode(Request.QueryString["prodColor"]);

    }
}