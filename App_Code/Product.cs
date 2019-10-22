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
/// Product Model to show the data except an entire ProductEntity model
/// </summary>
/// 

public class Product
{
    public short ProductId { get; set; }
    public string ProductCode { get; set; }
    public string ProductCat { get; set; }
    public string ProductName { get; set; }
    public string ProductStyle { get; set; }
    public string ProductColor { get; set; }
    public string ProductImg { get; set; }
    public string ProductDisc { get; set; }
    public int ProductPrice { get; set; }
    public string ProductNewArrival { get; set; }
    public string ProductSize { get; set; }
    public short ProductSizeQuantM { get; set; }
    public short ProductSizeQuantXL { get; set; }
    public short ProductSizeQuantXXL { get; set; }

}