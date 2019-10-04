using System;
using System.Collections.Generic;

using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Security.Claims;
using System.Web.Http.Cors;

[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
public class AdminController : ApiController
{
    online_tshirt_designingEntities designEntity;

    // GET api/<controller>
    [Authorize( Roles = "Admin")]
    [HttpGet]
    [Route("api/admin/customerOrderedProduct")]  
    public IHttpActionResult GetCustomersOrderedProducts()
    {
        ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
     //   Ok< Tuple<string, int> >();
        return Ok("Hello" + " " + identity.Name);
    }

    [HttpPost]
    [Route("api/admin/saveBannerDetails")]  
    public IHttpActionResult SaveBannerData([FromBody] HomeBannerModel bannerData)
    {
     

        return Ok("cool");
    }

    
    // POST api/<controller>
    //[Route("api/admin/CheckAdminLogin/{theAdminName}/{theAdminPwd}")]
    [Authorize]
    [HttpPost]
    public IHttpActionResult CheckAdminLogin([FromUri]string theAdminName, string theAdminPwd)
    {
        designEntity = new online_tshirt_designingEntities();

        //Check the admin credientials 1st
        string adminCredientialsMatch = designEntity.admins.Where((p) => p.AdminName == theAdminName && p.AdminPwd == theAdminPwd).Select((p) => p.AdminId.ToString()).SingleOrDefault();

        //If Admin hasn't got any credientials
        if (String.IsNullOrEmpty(adminCredientialsMatch)) return Ok<bool>(false);

        //If he has got the credientials
        //Create the session named AdminToken to use Session functionality
        //and store the client side stored token in the session to check the expiry

        //Set session time out i.e(15)minutes to increase Server memory performance
       

        return Ok<sbyte>(Convert.ToSByte(adminCredientialsMatch));
    }

    // PUT api/<controller>/5
    [HttpPut]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete]
    public void Delete(int id)
    {
    }
}
