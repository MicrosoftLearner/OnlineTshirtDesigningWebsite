using System;
using System.Collections.Generic;

using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

public class AdminController : ApiController
{
    online_tshirt_designingEntities designEntity;
    // GET api/<controller>

    [HttpGet]
    public IHttpActionResult CheckAdminLogin()
    {
        

    }


    // POST api/<controller>
    [HttpPost]
    public IHttpActionResult CheckAdminLogin([FromBody]string theAdminName, string theAdminPwd)
    {
        designEntity = new online_tshirt_designingEntities();

        //Check the admin credientials 1st
        string adminCredientialsMatch = designEntity.admins.Where((p) => p.AdminName == theAdminName && p.AdminPwd == theAdminPwd).Select((p) => p.AdminId.ToString()).SingleOrDefault();

        //If Admin hasn't got any credientials
        if (String.IsNullOrEmpty(adminCredientialsMatch)) return Ok<bool>(false);

        //If he has got the credientials
        return Ok<bool>(true);
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
}
