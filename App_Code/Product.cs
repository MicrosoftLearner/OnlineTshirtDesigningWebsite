using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Configuration;

/// <summary>
/// Product is the class in which all Product related info is present
/// Such as buying product , canceling ordered Product , and all ther things 
/// Which a Customer can do 
/// </summary>
/// 
[Serializable]
public class Product: Shopping
{
    public string ProductCode { get; set; }

    public string ProductCat { get; set; }

    public string ProductName { get; set; }

    public string ProductStyle { get; set; }

    public string ProductColor { get; set; }

    public string ProductImg { get; set; }

    public string ProductDesc { get; set; }

    public int ProductPrice { get; set; }

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