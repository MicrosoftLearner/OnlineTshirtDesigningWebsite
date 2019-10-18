using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Cart Model to show the data except an entire product_cart entity model
/// </summary>
public class CartModel
{
    public string ProductCartId { get; set; }

    public short ProductId { get; set; }

    public double ProductQuantityPrice { get; set; }

    public string CustId { get; set; }
   
    //Sets the product quantity i.e by default 1
    private short productQuantity = 1;

    public short ProductQuantity
    {
        get
        {
            return productQuantity;
        }

        set
        {
            productQuantity = value;
        }
    }

    //Sets the initial product price to 0
    private double productPrice = 0;

    public double ProductPrice
    {
        get
        {
            return productPrice;
        }

        set
        {
            productPrice += value * ProductQuantity;
        }
    }
}