using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManipulateCustomerData
/// </summary>

[Serializable]
public class  ManipulateCustomerData
{
    private Dictionary<int, Customer> custIdentity;

    private Customer CustomerToDeal;

    public Dictionary<int, Customer> ShowCustIdentity()
    {
        return custIdentity;
    }

    //public void AddCustIdentity(int theCustAddrId)
    //{
        
    //}

    public ManipulateCustomerData()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public ManipulateCustomerData(int theId, string theCustFirstName, string theCustLastName, string theCustFullName, int theCustMobNo, string theEmailId, string theCustShipAddr, string theCustShipCountry, string theCustShipState, string theCustShipCity, int theCustShipPinCode)
    {
        //Add the multiple shipping addr and other details in 
        //Dictionary to get multiple details to save in DataSource 

        custIdentity = new Dictionary<int, Customer>();

        custIdentity.Add(theId, new Customer(theCustFirstName, theCustLastName, theCustFullName, theCustMobNo, theEmailId, theCustShipAddr, theCustShipCountry, theCustShipState, theCustShipCity, theCustShipPinCode));

        //custIdentity.Add(theId, CustomerToDeal);

    }


}