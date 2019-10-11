using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Web.Http;
using System.Web.Http.Cors;
using System.Security.Claims;

using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using System.Net;
using System.Net.Http;
using System.Net.Mail;

//To use configuration files 
using System.Configuration;

using System.IO;


[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
public class CustomerController : ApiController
{
    online_tshirt_designingEntities designEntity;

    //GET api/<controller/id
    [Route("api/customer/getData/{id}")]
    [HttpGet]
    public IHttpActionResult GetCustomer(string id)
    {
        designEntity = new online_tshirt_designingEntities();

        CustomerModel customerData = designEntity.customers.Where(c => c.CustId == id).Select(x => new CustomerModel
        {
            CustFirstName = x.CustFirstName,

            CustLastName = x.CustLastName,

            CustEmailAddr = x.CustEmailAddr,

            CustImg = x.CustImg

        }).FirstOrDefault();


        return Ok(customerData);

    }

    [Route("api/customer/login")]
    [HttpPost]
    public IHttpActionResult Login([FromBody]  CustomerModel theCustomer)
    {
        //Instantiate the object
        designEntity = new online_tshirt_designingEntities();


        string matchesLogin = designEntity.customers.Where((log) => log.CustEmailAddr == theCustomer.CustEmailAddr && log.CustPwd == theCustomer.CustPwd).Select(log => log.CustId.ToString()).FirstOrDefault();

        //Checks for empty string i.e if no login info is found 
        if (string.IsNullOrEmpty(matchesLogin)) return NotFound();
     
        //returns the custmer Id if login credential is found 
        return Ok(matchesLogin);
        
    }
    // POST api/<controller>
    [Route("api/customer/signUp")]
    [HttpPost]
    public IHttpActionResult SignUp([FromBody] CustomerModel theCustomer)
    {
        //Instantiate the obj 1st
        designEntity = new online_tshirt_designingEntities();

        //To generate random numbers for HomeBaneerImgId column
        DateTime dTime = DateTime.Now;


        //Set Unique id to CustId & CustAddrId column
        string id = Convert.ToString(dTime.Millisecond);

        int updatedRecord = 0; //Will update if SaveChanges() updates record successfully

        //Check if Customer has already an EmailID or not  
        var customerPresent = designEntity.customers.FirstOrDefault((c) => c.CustEmailAddr == theCustomer.CustEmailAddr);

        //FirstOrDefault returns null if matching record is not found
          if (customerPresent != null) return NotFound();

        //If not, Insert the details into Database i.e(Entity Database) 
        var newCustomer = new customer()
        {

            //Add properties to Class
            CustId = id,

            CustFirstName = theCustomer.CustFirstName,

            CustLastName = theCustomer.CustLastName,

            CustPwd = theCustomer.CustPwd,

            CustMobNo = theCustomer.CustMobNo,

            CustEmailAddr = theCustomer.CustEmailAddr,

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
        if (updatedRecord > 0)
        {
            //Mail info to client

            SendMail(new Tuple<string, string>(theCustomer.CustEmailAddr, theCustomer.CustFullName));
            return Ok(true);

        }

        return Ok(true);

    }

   [NonAction]
    private void SendMail(Tuple<string, string> tupleCustomer)
    {

        //Initialize this Obj for Email 
        CustomerMail custMail = new CustomerMail();

        //will take .html Email Template 
        custMail.EmailSenderFileName = "WelcomeEmailer.html";

        //will set the Email subject
        custMail.EmailSubject = "Welcome To Burnt Umber";

        //will replace the [CustFullName] word from Template 

        //Use Srtring Bulder class to Replace multiple things 
        StringBuilder emailContentReplaceText = new StringBuilder(custMail.EmailContentText);

        emailContentReplaceText.Replace("[CustEmail]", tupleCustomer.Item1);

        emailContentReplaceText.Replace("[CustFullName]", tupleCustomer.Item2);

        //Set the replaced one text 
        custMail.EmailContentText = emailContentReplaceText.ToString();

        //Set to which customer Email id 
        custMail.EmailRecieverId = tupleCustomer.Item1;

        //Send mail to the recipant
        custMail.SendingMail();

    }

    [Route("api/customer/getAddresses/{id}")]
    [HttpGet]
    public IHttpActionResult GetAddresses(string id)
    {
        designEntity = new online_tshirt_designingEntities();

        //If A customer has got details along with Shipping details
        //Return this customerEntireData
        var customerEntireData = from cust in designEntity.customers
                                 join custAddr in designEntity.customer_address
                                 on cust.CustId equals custAddr.CustId
                                 where cust.CustId == id
                                 select new
                                 {
                                     cust.CustFirstName,
                                     cust.CustLastName,
                                     cust.CustMobNo,
                                     cust.CustEmailAddr,
                                     cust.CustImg,

                                     custAddr.CustAddrId,
                                     custAddr.CustShipAddr,
                                     custAddr.CustShipCity,
                                     custAddr.CustShipState,
                                     custAddr.CustShipPinCode

                                 };

        //Returns customerData If customer hasnt got any Shipping Details 
        //Saved in 

        if (customerEntireData.Count() == 0)
        {

            CustomerModel customerData = designEntity.customers.Where(c => c.CustId == id).Select(x => new CustomerModel
            {
                CustFirstName = x.CustFirstName,

                CustLastName = x.CustLastName,

                CustMobNo = (short)x.CustMobNo,

                CustEmailAddr = x.CustEmailAddr,

                CustImg = x.CustImg

            }).FirstOrDefault();

            return Ok(customerData);
        }

        return Ok(customerEntireData);
    }


    [Route("api/customer/saveAddr")]
    [HttpPost]
    public IHttpActionResult SaveCustomerAddress([FromBody] customer_address customerAddrr)
    {
        //To generate random numbers for HomeBaneerImgId column
        DateTime dTime = DateTime.Now;


        //Set Unique id to CustId & CustAddrId column
        string id = Convert.ToString(dTime.Millisecond);

        int updatedRecord = 0;

        //Insert the details into database i.e(EntityDatabase)
        var newCustomerAddrr = new customer_address {

            //Add properties to the class
            CustAddrId = id,

            CustShipAddr = customerAddrr.CustShipAddr,

            CustShipCountry = customerAddrr.CustShipCountry,

            CustShipState = customerAddrr.CustShipState,

            CustShipCity = customerAddrr.CustShipCity,

            CustShipPinCode = customerAddrr.CustShipPinCode
        };

        try
        {
            //Finally commit the changes the changes and insert the record
            //In the database
            designEntity.customer_address.Add(newCustomerAddrr);

            updatedRecord = designEntity.SaveChanges();

        }
        catch (Exception error)
        {

            System.Diagnostics.Debug.WriteLine("Error in Linq", error);
        }

        //IF records get updated successfully
        //if (updatedRecord > 0)
        //{

        //    return Ok();
        //}

        return Ok();
    }
    
    [HttpPost]
    public IHttpActionResult UpdateCustomerInfo([FromBody] string id, customer theCustomer){
        //Instantiate the object
        designEntity = new online_tshirt_designingEntities();

        int updatedRecord = 0;

        var updateCustoemerAddrr = from cust in designEntity.customers
                                   where cust.CustId == id
                                   select cust;

       
        //Execute the Query and return the Object
        customer custAddrrToUpdate = updateCustoemerAddrr.Single();

        //Change the Entity object
        custAddrrToUpdate.CustFirstName = theCustomer.CustFirstName;

        custAddrrToUpdate.CustLastName = theCustomer.CustLastName;

        custAddrrToUpdate.CustMobNo = theCustomer.CustMobNo;

        custAddrrToUpdate.CustEmailAddr = theCustomer.CustEmailAddr;

        //Commit the changes back to the database

        try
        {
          updatedRecord =  designEntity.SaveChanges();

        }
        catch (Exception error)
        {

            System.Diagnostics.Debug.WriteLine(error);
        }

        return Ok<string>("User info has been successfully updated");

    }

    [HttpPost]
    public IHttpActionResult UpdateCustomerAddress([FromBody] string id, customer_address customerAddrr)
    {
        //Instantiate the object
        designEntity = new online_tshirt_designingEntities();

        int updatedRecord = 0;

        var updateCustoemerAddrr = from cust in designEntity.customer_address
                                   where cust.CustAddrId == id
                                   orderby cust.CustShipAddr
                                   select cust;

        //Execute the Query and return the Object
        customer_address custAddrrToUpdate = updateCustoemerAddrr.Single();

        //Change the Entity object
        custAddrrToUpdate.CustShipAddr = customerAddrr.CustShipAddr;

        custAddrrToUpdate.CustShipCountry = customerAddrr.CustShipCountry;

        custAddrrToUpdate.CustShipState = customerAddrr.CustShipState;

        custAddrrToUpdate.CustShipCity = customerAddrr.CustShipCity;

        custAddrrToUpdate.CustShipPinCode = customerAddrr.CustShipPinCode;

        //Commit the changes back to the database
        try
        {
           updatedRecord =  designEntity.SaveChanges();

        }
        catch (Exception)
        {

            System.Diagnostics.Debug.WriteLine("Entity Update Error");
        } 

        return Ok<string>("Address updated successfully");
    }
    
    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void DeleteCustomerAddress(string id)
    {
        //Instantiate the obj
        designEntity = new online_tshirt_designingEntities();

        //Find an appropriate Customer Address
        var matches = from c in designEntity.customer_address
                      where c.CustAddrId == id
                      orderby c.CustAddrId
                      select c;

        //Excute the query and return the Object
        customer_address customerAddrr = matches.Single();

        //Delete the record from the Database
        designEntity.customer_address.Remove(customerAddrr);

        designEntity.SaveChanges();
                      
    }


}
