using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManipulateCustomerData
/// </summary>

[Serializable]
public class ManipulateCustomerData
{
    private Dictionary<int, Customer> custIdentity = new Dictionary<int, Customer>();

    private Customer CustomerToDeal;

    public void AddCustIdentity(int theId, string theCustFirstName, string theCustLastName, string theCustFullName, int theCustMobNo, string theEmailId, string theCustShipAddr, string theCustShipCountry, string theCustShipState, string theCustShipCity, int theCustShipPinCode)
    {
        custIdentity.Add(theId, new Customer(theCustFirstName, theCustLastName, theCustFullName, theCustMobNo, theEmailId, theCustShipAddr, theCustShipCountry, theCustShipState, theCustShipCity, theCustShipPinCode));
    }

    public Dictionary<int, Customer> ShowCustIdentity()
    {
        return custIdentity;
    }

    public ManipulateCustomerData()
    {
        //
        // TODO: Add constructor logic here
        //

    }

}