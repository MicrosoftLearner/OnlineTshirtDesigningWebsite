using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Product is the class in which all Product related info is present
/// Such as buying product , canceling ordered Product , and all ther things 
/// Which a Customer can do 
/// </summary>
public class Product: Shopping
{
    public int ProductCode { get; set; }

    public string ProductName { get; set; }

    public string ProductStyle { get; set; }

    public string ProductColor { get; set; }

    public string ProductImg { get; set; }

    public string ProductDesc { get; set; }

    public double ProductPrice { get; set; }

    public string ProductSizeName { get; set; }

    public string ProductSizeQuant { get; set; }

    public string ProductNewArrival { get; set; }

    public int ProductOrderId { get; set; }

    public string ProductOrderTime { get; set; }

    public string ProductPaymentMethd { get; set; }

    public string CustComment { get; set; }

    public Product()
    {
          
        //
        // TODO: Add constructor logic here
        //
    }


}