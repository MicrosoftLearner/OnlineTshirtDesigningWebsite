using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccount_UserAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Table> orderedProductList = new List<Table>();
        int productCatCount = 5;

        Panel pannelUserOrderedProductInfo0; // which will create panel in td
        Panel pannelUserOrderedProductInfo1;  // which will create panel in td
        Panel pannelUserOrderedProductInfo2; // which will create panel in td
        Image productImage;
        Button userProductChoiceCancel;
        Button userProductChoiceOrderdtl;
        Button userProductChoiceOrderdInvoice;

        Label labelUserOrderedProductName;

        for (int i = 0; i < 2; i++)
        {
            Table table = new Table();
            table.ID = "TableUserOrder" + i.ToString();
            table.CssClass = "table";

            TableHeaderRow tr = new TableHeaderRow();
            tr.CssClass = "relate";
            table.Controls.Add(tr);


            for (int thead = 0; thead < productCatCount; thead++)
            {
                /*<thead> <tr><th></th> </tr></thead>*/

                tr.TableSection = TableRowSection.TableHeader;
                TableHeaderCell th = new TableHeaderCell();
                th.Text = "Product (" + thead.ToString() + ")";
                th.CssClass = "align-top";
                tr.Cells.Add(th);
                table.Rows.Add(tr);
            }

            tr = new TableHeaderRow();
            table.Controls.Add(tr);

            tr.TableSection = TableRowSection.TableBody;
            TableCell td = new TableCell();

            pannelUserOrderedProductInfo0 = new Panel();
            pannelUserOrderedProductInfo0.ID = "PannelUserOrderedProductInfo";
            pannelUserOrderedProductInfo0.CssClass = "item-img display-cell align-top";

            productImage = new Image();
            productImage.ImageUrl = "../Images/Home/10.jpg";
            productImage.CssClass = "img-responsive";
            // 1st add image in td

            // add image to 1st pannel 
            pannelUserOrderedProductInfo0.Controls.Add(productImage);
            td.Controls.Add(pannelUserOrderedProductInfo0);

            TableCell td1 = new TableCell();
            pannelUserOrderedProductInfo1 = new Panel();
            labelUserOrderedProductName = new Label();
            labelUserOrderedProductName.Text = "Linen Full sleeve shirt";
            labelUserOrderedProductName.Text += "Product Code";
            //add label to another pannel
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductName);
            td1.Controls.Add(pannelUserOrderedProductInfo1);

            TableCell td2 = new TableCell();

            userProductChoiceCancel = new Button();
            userProductChoiceCancel.ID = "ButtonUserProductChoiceCancel";
            userProductChoiceCancel.CssClass = "btn order-action--btn text-uppercase";
            userProductChoiceCancel.Text = "Cancel purchase";

            userProductChoiceOrderdtl = new Button();
            userProductChoiceOrderdtl.ID = "ButtonUserProductChoiceOrderDtl";
            userProductChoiceOrderdtl.CssClass = "btn order-action--btn text-uppercase";
            userProductChoiceOrderdtl.Text = "order detail";

            userProductChoiceOrderdInvoice = new Button();
            userProductChoiceOrderdInvoice.ID = "ButtonUserProductChoiceOrderInvoi";
            userProductChoiceOrderdInvoice.CssClass = "btn order-action--btn text-uppercase";
            userProductChoiceOrderdInvoice.Text = "Download invoice";

            pannelUserOrderedProductInfo2 = new Panel();
            pannelUserOrderedProductInfo2.Controls.Add(userProductChoiceCancel);
            pannelUserOrderedProductInfo2.Controls.Add(userProductChoiceOrderdtl);
            pannelUserOrderedProductInfo2.Controls.Add(userProductChoiceOrderdInvoice);
            td2.Controls.Add(pannelUserOrderedProductInfo2);

            //add all td to TableRow obj
            tr.Controls.Add(td);
            tr.Controls.Add(td1);
            tr.Controls.Add(td2);

            //for (int tbody = 0; tbody < 3; tbody++)
            //{
            //    /*<tbody><tr><td></tr>*/

            //    tr.TableSection = TableRowSection.TableBody;
            //    TableCell td = new TableCell();


            //    //tr.Cells.Add(td);
            //    // Put table cell in the TableRow
            //    tr.Controls.Add(td);

            //    // table.Rows.Add(tr);
            //}

            orderedProductList.Add(table);

        }

        foreach (Table item in orderedProductList)
        {
            PanelUserOrderTable.Controls.Add(item);
        }
    }

    protected void ButtonUserReturn_Click(object sender, EventArgs e)
    {
        MultiViewUserOrdered.ActiveViewIndex = 1;

        List<Table> returnedProductList = new List<Table>();
        int productCatCount = 5;

        Panel pannelUserOrderedProductInfo0; // which will create panel in td
        Panel pannelUserOrderedProductInfo1;  // which will create panel in td
        Panel pannelUserOrderedProductInfo2; // which will create panel in td
        Image productImage;

        Button userProductChoiceOrderdtl;
        Button userProductChoiceOrderdInvoice;

        Label labelUserOrderedProductName;

        for (int i = 0; i < 2; i++)
        {
            Table table = new Table();
            table.ID = "TableUserOrder" + i.ToString();
            table.CssClass = "table";

            TableHeaderRow tr = new TableHeaderRow();
            tr.CssClass = "relate";
            table.Controls.Add(tr);


            for (int thead = 0; thead < productCatCount; thead++)
            {
                /*<thead> <tr><th></th> </tr></thead>*/

                tr.TableSection = TableRowSection.TableHeader;
                TableHeaderCell th = new TableHeaderCell();
                th.Text = "Product (" + thead.ToString() + ")";
                th.CssClass = "align-top";
                tr.Cells.Add(th);
                table.Rows.Add(tr);
            }

            tr = new TableHeaderRow();
            table.Controls.Add(tr);

            tr.TableSection = TableRowSection.TableBody;
            TableCell td = new TableCell();

            pannelUserOrderedProductInfo0 = new Panel();
            pannelUserOrderedProductInfo0.ID = "PannelUserOrderedProductInfo";
            pannelUserOrderedProductInfo0.CssClass = "item-img display-cell align-top";
            productImage = new Image();
            productImage.ImageUrl = "../Images/Home/10.jpg";
            productImage.CssClass = "img-responsive";
            // 1st add image in td

            // add image to 1st pannel 
            pannelUserOrderedProductInfo0.Controls.Add(productImage);
            td.Controls.Add(pannelUserOrderedProductInfo0);

            TableCell td1 = new TableCell();
            pannelUserOrderedProductInfo1 = new Panel();
            pannelUserOrderedProductInfo1.CssClass = " item - desc display - cell align - top";

            labelUserOrderedProductName = new Label();
            labelUserOrderedProductName.Text = "Linen Full sleeve shirt" + "<br/>";

            Label labelUserOrderedProductCode = new Label();
            labelUserOrderedProductCode.CssClass = "item-code";
            labelUserOrderedProductCode.Text = "Product Code:" + 565666666.ToString() + "<br />";

            Label labelUserProductPrice = new Label();
            labelUserProductPrice.CssClass = "cost";
            labelUserProductPrice.Text = "&#8377; " + 4500.ToString();

            //add label to another pannel
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductName);
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductCode);
            pannelUserOrderedProductInfo1.Controls.Add(labelUserProductPrice);

            td1.Controls.Add(pannelUserOrderedProductInfo1);

            TableCell td2 = new TableCell();

            userProductChoiceOrderdtl = new Button();
            userProductChoiceOrderdtl.ID = "ButtonUserProductChoiceOrderDtl";
            userProductChoiceOrderdtl.CssClass = "btn order-action--btn text-uppercase";
            userProductChoiceOrderdtl.Text = "order detail";

            userProductChoiceOrderdInvoice = new Button();
            userProductChoiceOrderdInvoice.ID = "ButtonUserProductChoiceOrderInvoi";
            userProductChoiceOrderdInvoice.CssClass = "btn order-action--btn text-uppercase";
            userProductChoiceOrderdInvoice.Text = "Buy it again";
            userProductChoiceOrderdInvoice.OnClientClick = "UserProductByAgain_Click";

            pannelUserOrderedProductInfo2 = new Panel();
            pannelUserOrderedProductInfo2.Controls.Add(userProductChoiceOrderdtl);
            pannelUserOrderedProductInfo2.Controls.Add(userProductChoiceOrderdInvoice);
            td2.Controls.Add(pannelUserOrderedProductInfo2);

            //add all td to TableRow obj
            tr.Controls.Add(td);
            tr.Controls.Add(td1);
            tr.Controls.Add(td2);

            //for (int tbody = 0; tbody < 3; tbody++)
            //{
            //    /*<tbody><tr><td></tr>*/

            //    tr.TableSection = TableRowSection.TableBody;
            //    TableCell td = new TableCell();


            //    //tr.Cells.Add(td);
            //    // Put table cell in the TableRow
            //    tr.Controls.Add(td);

            //    // table.Rows.Add(tr);
            //}

            returnedProductList.Add(table);

        }

        foreach (Table item in returnedProductList)
        {
            PanelUserOrderReturnTable.Controls.Add(item);
        }

    }

    protected void ButtonUserCancelled_Click(object sender, EventArgs e)
    {

        MultiViewUserOrdered.ActiveViewIndex = 2;
        List<Table> cancelledProductList = new List<Table>();
        int productCatCount = 5;

        Panel pannelUserOrderedProductInfo0; // which will create panel in td
        Panel pannelUserOrderedProductInfo1;  // which will create panel in td
        Panel pannelUserOrderedProductInfo2; // which will create panel in td
        Image productImage;

        Button userProductChoiceOrderdInvoice;

        Label labelUserOrderedProductName;

        for (int i = 0; i < 2; i++)
        {
            Table table = new Table();
            table.ID = "TableUserOrder" + i.ToString();
            table.CssClass = "table";

            TableHeaderRow tr = new TableHeaderRow();
            tr.CssClass = "relate";
            table.Controls.Add(tr);


            for (int thead = 0; thead < productCatCount; thead++)
            {
                /*<thead> <tr><th></th> </tr></thead>*/

                tr.TableSection = TableRowSection.TableHeader;
                TableHeaderCell th = new TableHeaderCell();
                th.Text = "Product (" + thead.ToString() + ")";
                th.CssClass = "align-top";
                tr.Cells.Add(th);
                table.Rows.Add(tr);
            }

            tr = new TableHeaderRow();
            table.Controls.Add(tr);

            tr.TableSection = TableRowSection.TableBody;
            TableCell td = new TableCell();

            pannelUserOrderedProductInfo0 = new Panel();
            pannelUserOrderedProductInfo0.ID = "PannelUserOrderedProductInfo";
            pannelUserOrderedProductInfo0.CssClass = "item-img display-cell align-top";
            productImage = new Image();
            productImage.ImageUrl = "../Images/Home/10.jpg";
            productImage.CssClass = "img-responsive";
            // 1st add image in td

            // add image to 1st pannel 
            pannelUserOrderedProductInfo0.Controls.Add(productImage);
            td.Controls.Add(pannelUserOrderedProductInfo0);

            TableCell td1 = new TableCell();
            pannelUserOrderedProductInfo1 = new Panel();
            pannelUserOrderedProductInfo1.CssClass = " item - desc display - cell align - top";

            labelUserOrderedProductName = new Label();
            labelUserOrderedProductName.Text = "Linen Full sleeve shirt" + "<br/>";

            Label labelUserOrderedProductCode = new Label();
            labelUserOrderedProductCode.CssClass = "item-code";
            labelUserOrderedProductCode.Text = "Product Code:" + 565666666.ToString() + "<br />";

            Label labelUserProductPrice = new Label();
            labelUserProductPrice.CssClass = "cost";
            labelUserProductPrice.Text = "&#8377; " + 4500.ToString();

            //add label to another pannel
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductName);
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductCode);
            pannelUserOrderedProductInfo1.Controls.Add(labelUserProductPrice);

            td1.Controls.Add(pannelUserOrderedProductInfo1);

            TableCell td2 = new TableCell();

            userProductChoiceOrderdInvoice = new Button();
            userProductChoiceOrderdInvoice.ID = "ButtonUserProductChoiceOrderInvoi";
            userProductChoiceOrderdInvoice.CssClass = "btn order-action--btn text-uppercase";
            userProductChoiceOrderdInvoice.Text = "Buy it again";
            userProductChoiceOrderdInvoice.OnClientClick = "UserProductByAgain_Click";

            pannelUserOrderedProductInfo2 = new Panel();
            pannelUserOrderedProductInfo2.Controls.Add(userProductChoiceOrderdInvoice);
            td2.Controls.Add(pannelUserOrderedProductInfo2);

            //add all td to TableRow obj
            tr.Controls.Add(td);
            tr.Controls.Add(td1);
            tr.Controls.Add(td2);

            //for (int tbody = 0; tbody < 3; tbody++)
            //{
            //    /*<tbody><tr><td></tr>*/

            //    tr.TableSection = TableRowSection.TableBody;
            //    TableCell td = new TableCell();


            //    //tr.Cells.Add(td);
            //    // Put table cell in the TableRow
            //    tr.Controls.Add(td);

            //    // table.Rows.Add(tr);
            //}

            cancelledProductList.Add(table);

        }

        foreach (Table item in cancelledProductList)
        {
            PanelUserOrderCancelTable.Controls.Add(item);
        }
    }

    protected void ButtonUserOrders_Click(object sender, EventArgs e)
    {
        MultiViewUserOrdered.ActiveViewIndex = 0;
    }

    protected void LinkButtonUserProf_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
    }
}