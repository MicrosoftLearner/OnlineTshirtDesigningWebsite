using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class UserOrderDetails_OrderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        List<Table> orderDtlProductList = new List<Table>();
        List<Table> orderReturnProductList = orderDtlProductList;
        int productCatCount = 5;

        Panel pannelUserOrderedProductInfo0; // which will create panel in td
        Panel pannelUserOrderedProductInfo1;  // which will create panel in td
        Panel pannelUserOrderedProductInfo2; // which will create panel in td
        Image productImage;

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
            pannelUserOrderedProductInfo1.CssClass = " item-desc display-cell align-top";

            labelUserOrderedProductName = new Label();
            labelUserOrderedProductName.Text = "Linen Full sleeve shirt" + "<br/>";

            Label labelUserOrderedProductCode = new Label();
            labelUserOrderedProductCode.CssClass = "item-code";
            labelUserOrderedProductCode.Text = "Product Code:" + 565666666.ToString() + "<br />";

            Label labelUserOrderedProductSize = new Label();
            labelUserOrderedProductSize.CssClass = "item-code";
            labelUserOrderedProductSize.Text = "Size: " + "M" + "<br/>";
            labelUserOrderedProductSize.Text += "Color: " + "black" + "<br/><br/>";

            Label labelUserProductPrice = new Label();
            labelUserProductPrice.CssClass = "cost";
            labelUserProductPrice.Text = "&#8377; " + 4500.ToString();

            //add label to another pannel
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductName);
            pannelUserOrderedProductInfo1.Controls.Add(labelUserOrderedProductCode);
            pannelUserOrderedProductInfo1.Controls.Add(labelUserProductPrice);

            td1.Controls.Add(pannelUserOrderedProductInfo1);

            TableCell td2 = new TableCell();

            HtmlGenericControl topNewControl = new HtmlGenericControl("div");
            HtmlGenericControl userQuantityHead = new HtmlGenericControl("h4");
            userQuantityHead.Attributes["class"] = "usr-status-title";
            userQuantityHead.InnerText = "quantity";

            HtmlGenericControl newControl = new HtmlGenericControl("div");
            newControl.Attributes["class"] = "usr-status plus-minus-btn";


            HtmlGenericControl newControl1 = new HtmlGenericControl("div");
            newControl1.Attributes["class"] = "inline-block";

            HtmlGenericControl newControl2 = new HtmlGenericControl("div");
            newControl2.Attributes["class"] = "form-group marg0";

            HtmlInputText quantityIp = new HtmlInputText();
            quantityIp.Attributes["class"] = "form-control quantity__input";
            quantityIp.Attributes.Add("readonly", "readonly");

            newControl2.Controls.Add(quantityIp);

            newControl.Controls.Add(newControl1);
            newControl1.Controls.Add(newControl2);


            topNewControl.Controls.Add(userQuantityHead);
            topNewControl.Controls.Add(newControl);

            pannelUserOrderedProductInfo2 = new Panel();
            pannelUserOrderedProductInfo2.Controls.Add(topNewControl);
            td2.Controls.Add(pannelUserOrderedProductInfo2);

            TableCell td3 = new TableCell();
            Label labelUserProductGrandTotal = new Label();
            labelUserProductGrandTotal.CssClass = "item-cost grand-total";
            labelUserProductGrandTotal.Text = "&#8377; " + 4500.ToString();
            td3.Controls.Add(labelUserProductGrandTotal);
            //add all td to TableRow obj
            tr.Controls.Add(td);
            tr.Controls.Add(td1);
            tr.Controls.Add(td2);
            tr.Controls.Add(td3);

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

            orderDtlProductList.Add(table);

        }

        foreach (Table item in orderDtlProductList)
        {
            PanelOrderDtlTable.Controls.Add(item);

        }
    }
}