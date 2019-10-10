using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerModel
/// </summary>
public class CustomerModel
{
    public string CustId { get; set; }
    public string CustFirstName { get; set; }
    public string CustLastName { get; set; }
    public string CustPwd { get; set; }
    public short CustMobNo { get; set; }
    public string CustEmailAddr { get; set; }
    public string CustImg { get; set; }

    public string CustFullName
    {
        get
        {
            return CustFirstName + " " + CustLastName;
        }
    }
    public CustomerModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}