using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer : Shopping
{
    public string CustFirstName { get; set; }
    public string CustLastName { get; set; }
    public int CustMobNo { get; set; }
    public bool CustAggree { get; set; }
    public string CustImg { get; set; }
    public string CustShippAddr { get; set; }
    public string CustShipCountry { get; set; }
    public string CustShipState { get; set; }

    public string CustShipCity { get; set; }
    public int CustShipPinCode { get; set; }
    public string CustComment { get; set; }

    public Customer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}