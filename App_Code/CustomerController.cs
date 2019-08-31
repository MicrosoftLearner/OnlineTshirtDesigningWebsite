using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

public class CustomerController : ApiController
{
    online_tshirt_designingEntities1 designEntity;
    
    //GET api/<controller/id
   // [Route("api/customer/GetCustomerEntireData/{Id}")]
    [HttpGet]
    public IHttpActionResult GetCustomer(int id)
    {
        designEntity = new online_tshirt_designingEntities1();

        var customerEntireData = from cust in designEntity.customers
                                 join custAddr in designEntity.customer_address
                                 on cust.CustId equals custAddr.CustId
                                 where cust.CustId == id
                                 select cust;

        return Ok(customerEntireData);
    }

    // POST api/<controller>
    [HttpPost]
    public IHttpActionResult SignUp([FromBody]string firstName, string lastName, string pwd, int mobNo, string emailId, string img)
    {
        //Instantiate the obj 1st
        designEntity = new online_tshirt_designingEntities1();

        //To generate random numbers for HomeBaneerImgId column
        DateTime dTime = DateTime.Now;


        //Set Unique id to CustId & CustAddrId column
        string id = Convert.ToString(dTime.Millisecond);

        int updatedRecord = 0; //Will update if SaveChanges() updates record successfully

        //Check if Customer has already an EmailID or not  
        var customerPresent = designEntity.customers.FirstOrDefault((c) => c.CustEmailAddr == emailId);

        //FirstOrDefault returns null if matching record is not found
        if (customerPresent == null) return NotFound();

        //If not Insert the details into Database i.e(Entity Database) 
        var newCustomer = new customer() {

            //Add properties to Class
            CustId = Convert.ToSByte(id),

            CustFirstName = firstName,

            CustLastName = lastName,

            CustPwd = pwd,

            CustMobNo = Convert.ToSByte(mobNo),

            CustEmailAddr = emailId,

            CustImg = img
        };
        // customer x = customer.CreateProduct();


        try
        {
            //Finally commit the changes the changes and insert the record
            //In the database
            designEntity.customers.Add(newCustomer);

            updatedRecord = designEntity.SaveChanges();

        }
        catch (Exception error)
        {

            System.Diagnostics.Debug.WriteLine("Error in Linq", error);
        }

        //IF records get updated successfully
        return Ok(newCustomer);
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
