using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerAddressModel
/// </summary>
public class CustomerAddressModel
{
    public string CustAddrId { get; set; }

    public string CustShipAddr { get; set; }

    public string CustShipCountry { get; set; }

    public string CustShipState { get; set; }

    public string CustShipCity { get; set; }

    public int CustShipPinCode { get; set; }

    public string CustId { get; set; }
}