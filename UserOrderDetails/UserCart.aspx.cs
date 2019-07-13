using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class UserOrderDetails_UserCart : System.Web.UI.Page
{
    Label userCartProductQuant;
    int counter;
    protected void Page_Load(object sender, EventArgs e)
    {
        int userCartHeaderRowCount;
        userCartHeaderRowCount = UserCartHeaderRow.Cells.Count;

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + UserCartHeaderRowCount + ")", true);

        for (int i = 0; i < 3; i++)
        {
            TableRow userCartRow = new TableRow();
            userCartRow.CssClass = "relate";
            TableUserCart.Controls.Add(userCartRow);

            for (int j = 0; j < userCartHeaderRowCount; j++)
            {

                TableCell userCartCell = new TableCell();
                userCartCell.ID = "UserCartCell" + j.ToString().Trim();

                Image userCartItemImg = new Image();
                userCartItemImg.ImageUrl = "../Images/Home/10.jpg";
                // userCartItemImg.CssClass = "img-responsive";
                userCartItemImg.AlternateText = "Image";
                userCartItemImg.Width = 132;
                //userCartItemImg.ImageAlign = Top.ToString();

                Label userCartProductName = new Label();
                userCartProductName.Text = "Linen Cotton: " + i;

                Label userCartProductColor = new Label();
                userCartProductColor.Text = "red";

                Label userCartProductPrice = new Label();
                userCartProductPrice.Text = "1300";

                Label userCartProductSize = new Label();
                userCartProductSize.Text = "L";

                HtmlGenericControl quantityDiv = new HtmlGenericControl("div");
                quantityDiv.Attributes.Add("class", "plus-minus-btn");

                LinkButton quantityMinus = new LinkButton();
                quantityMinus.Attributes.Add("runat", "server");
                quantityMinus.ID = "DecreaseQuantity";
                quantityMinus.Click += new EventHandler(DecreaseQuantity_Click);


                LinkButton quantityPlus = new LinkButton();
                quantityPlus.Attributes.Add("runat", "server");
                quantityPlus.ID = "IncreaseQuantity";
                quantityPlus.Click += new EventHandler(IncreaseQuantity_Click);

                HtmlGenericControl quantityFaMinus = new HtmlGenericControl("i");
                quantityFaMinus.Attributes.Add("class", "fa fa-minus display-inblock square__bg");

                HtmlGenericControl quantityFaPlus = new HtmlGenericControl("i");
                quantityFaPlus.Attributes.Add("class", "fa fa-plus display-inblock square__bg");

                userCartProductQuant = new Label();
                userCartProductQuant.ID = "UserProductQuantity";
                userCartProductQuant.Text = "&nbsp; 4 &nbsp; ";

                quantityMinus.Controls.Add(quantityFaMinus);
                quantityPlus.Controls.Add(quantityFaPlus);

                quantityDiv.Controls.Add(quantityMinus); //anchor
                quantityDiv.Controls.Add(userCartProductQuant); // label
                quantityDiv.Controls.Add(quantityPlus); // anchor

                Label userCartProductTotal = new Label();
                userCartProductTotal.Text = "&#x20b9 &nbsp; 1400";

                userCartCell.TabIndex = (short)j;
                if (userCartCell.ID == "UserCartCell0")
                {
                    userCartCell.Width = 330;
                    userCartCell.Controls.Add(userCartItemImg);
                    userCartCell.Controls.Add(userCartProductName);
                }
                else if (userCartCell.ID == "UserCartCell1")
                {
                    userCartCell.Controls.Add(userCartProductColor);
                }
                else if (userCartCell.ID == "UserCartCell2")
                {
                    userCartCell.Controls.Add(userCartProductSize);

                }
                else if (userCartCell.ID == "UserCartCell3")
                {
                    userCartCell.Controls.Add(quantityDiv);

                }
                else if (userCartCell.ID == "UserCartCell4")
                {
                    userCartCell.Controls.Add(userCartProductPrice);

                }
                else if (userCartCell.ID == "UserCartCell5")
                {
                    userCartCell.Controls.Add(userCartProductTotal);

                }

                // put the tablecell in tablerow
                userCartRow.Controls.Add(userCartCell);

            }
        }
    }

    private void IncreaseQuantity_Click(object sender, EventArgs e)
    {
        //counter = 0;
        //counter++;
        //userCartProductQuant.Text = counter.ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('IncreaseQuantity_Click')", true);
    }

    private void DecreaseQuantity_Click(object sender, EventArgs e)
    {
        //counter--;
        //userCartProductQuant.Text = counter.ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DecreaseQuantity_Click')", true);
    }
}