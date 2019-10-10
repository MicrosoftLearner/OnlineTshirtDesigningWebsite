using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///   CustomerRepo will validate admin and also return the admin info
/// </summary>
public class CustomerRepository : IDisposable
{
    online_tshirt_designingEntities context = new online_tshirt_designingEntities();

    public customer ValidateAdmin(string theCustomerEmailAddr, string theCustomerPwd)
    {
        return context.customers.FirstOrDefault(cust => cust.CustEmailAddr.Equals(theCustomerEmailAddr, StringComparison.OrdinalIgnoreCase) && cust.CustPwd == theCustomerPwd);

    }


    public void Dispose()
    {

        context.Dispose();
    }
}