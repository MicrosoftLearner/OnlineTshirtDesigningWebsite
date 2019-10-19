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
    private double productQuantityPrice = 0;

    public double ProductQuantityPrice
    {
        get
        {
            return productQuantityPrice;
        }

        set
        {
            productQuantityPrice += value * ProductQuantity;
        }
    }
}