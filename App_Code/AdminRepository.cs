using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///   AdminRepository will validate admin and also return the admin info
/// </summary>
public class AdminRepository:IDisposable
{
    online_tshirt_designingEntities context = new online_tshirt_designingEntities();

    public admin ValidateAdmin(string theAdminName, string theAdminPwd)
    {
            return context.admins.FirstOrDefault(adm => adm.AdminName.Equals(theAdminName,StringComparison.OrdinalIgnoreCase) && adm.AdminPwd == theAdminPwd);

    }


    public void Dispose()
    {

       context.Dispose();
    }
}