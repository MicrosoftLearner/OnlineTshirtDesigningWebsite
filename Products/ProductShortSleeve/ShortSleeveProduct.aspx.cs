using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Products_ProductShortSleeve_ShortSleeveProduct : System.Web.UI.Page
{
    private bool productFilterView; // to switch FilterView UI
    protected void Page_Load(object sender, EventArgs e)
    {
        int mensStock = 30;
        if (this.IsPostBack == false)
        {
            // // For style
            //ChkBoxListStyle.Items.Add(new ListItem("Men's ('" + mensStock + "')", mensStock.ToString()));
            //ChkBoxListStyle.Items.Add(new ListItem("Women's ('" + mensStock + "')", mensStock.ToString()));
        }
        else
        {
            //Restore Varaible
            productFilterView = (bool)ViewState["FilterView"];
        }
    }
    protected void Page_Prerender(object sender, EventArgs e)
    {
        // Persist variable
        ViewState["FilterView"] = productFilterView;
    }

    protected void LnkBtnProductFilter_Click(object sender, EventArgs e)
    {
        if (productFilterView)
        {
            MlViewFilterChoice.ActiveViewIndex = 1;
            productFilterView = false;
            ViewState["FilterView"] = productFilterView;
        }

        else
        {
            MlViewFilterChoice.ActiveViewIndex = 0;
            productFilterView = true;
            ViewState["FilterView"] = productFilterView;

        }

    }
}