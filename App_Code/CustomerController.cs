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

            CustMobNo = (short)x.CustMobNo,

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
                                     cust.CustId,
                                     cust.CustFirstName,
                                     cust.CustLastName,
                                     cust.CustMobNo,
                                     cust.CustEmailAddr,
                                     cust.CustImg,

                                     custAddr.CustAddrId,
                                     custAddr.CustShipAddr,
                                     custAddr.CustShipCountry,
                                     custAddr.CustShipCity,
                                     custAddr.CustShipState,
                                     custAddr.CustShipPinCode

                                 };

        //Returns customerData If customer hasnt got any Shipping Details 
        //Saved in 

        if (customerEntireData.Count() == 0)
        {

            //CustomerModel customerData = designEntity.customers.Where(c => c.CustId == id).Select(x => new CustomerModel
            //{
            //    CustFirstName = x.CustFirstName,

            //    CustLastName = x.CustLastName,

            //    CustMobNo = (short)x.CustMobNo,

            //    CustEmailAddr = x.CustEmailAddr,

            //    CustImg = x.CustImg

            //}).FirstOrDefault();

            return NotFound();
        }

        return Ok(customerEntireData);
    }


    [Route("api/customer/saveNewAddr")]
    [HttpPost]
    public IHttpActionResult SaveCustomerAddress([FromBody] customer_address customerAddrr)
    {
        //To generate random numbers for HomeBaneerImgId column
        DateTime dTime = DateTime.Now;


        //Set Unique id to CustId & CustAddrId column
        string id = Convert.ToString(dTime.Millisecond);

        int updatedRecord = 0;

        //Insert the details into database i.e(EntityDatabase)
        var newCustomerAddrr = new customer_address
        {

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

    [Route("api/customer/saveRewrittenInfo")]
    [HttpPost]
    public IHttpActionResult UpdateCustomerInfo([FromBody] CustomerModel theCustomer)
    {
        //Instantiate the object
        designEntity = new online_tshirt_designingEntities();

        int updatedRecord = 0;

        //Execute the query and return the entity object 
        customer customerMatches = designEntity.customers.FirstOrDefault((c) => c.CustId == theCustomer.CustId);

        if (customerMatches != null)
        {

            //Change the Entity object
            customerMatches.CustFirstName = theCustomer.CustFirstName;

            customerMatches.CustLastName = theCustomer.CustLastName;

            customerMatches.CustMobNo = theCustomer.CustMobNo;

            customerMatches.CustEmailAddr = theCustomer.CustEmailAddr;

            customerMatches.CustImg = theCustomer.CustImg;

            //Commit the changes back to the database
            try
            {
                updatedRecord = designEntity.SaveChanges();

            }
            catch (Exception)
            {

                System.Diagnostics.Debug.WriteLine("Entity Update Error");
            }


        }

        if (updatedRecord > 0)
        {
            CustomerModel customerData = designEntity.customers.Where(c => c.CustId == theCustomer.CustId).Select(x => new CustomerModel
            {
                CustFirstName = x.CustFirstName,

                CustLastName = x.CustLastName,

                CustMobNo = (short)x.CustMobNo,

                CustEmailAddr = x.CustEmailAddr,

                CustImg = x.CustImg

            }).FirstOrDefault();

            return Ok(customerData);
        }

        return NotFound();
    }


    [Route("api/customer/saveRewrittenAddressInfo")]
    [HttpPost]
    public IHttpActionResult UpdateCustomerAddress([FromBody]  CustomerAddressModel theCustomer)
    {
        //Instantiate the object
        designEntity = new online_tshirt_designingEntities();

        int updatedRecord = 0;


        //Execute the query and return the entity object 
        customer_address customerMatches = designEntity.customer_address.FirstOrDefault((c) => c.CustAddrId == theCustomer.CustAddrId && c.CustId == theCustomer.CustId);

        if (customerMatches == null)
        {
            //Generates random numbers for CustAddrId column
            DateTime dTime = DateTime.Now;


            //Sets Unique id to CustId & CustAddrId column
            string id = Convert.ToString(dTime.Millisecond);

            //Creates the new customer address model
            customer_address newCustomerAddress = new customer_address
            {
                CustAddrId = id,

                CustShipAddr = theCustomer.CustShipAddr,

                CustShipCountry = theCustomer.CustShipCountry,

                CustShipState = theCustomer.CustShipState,

                CustShipCity = theCustomer.CustShipCity,

                CustShipPinCode = theCustomer.CustShipPinCode,

                CustId = theCustomer.CustId

            };

            try
            {
                //Finally commit the changes the changes and insert the record
                //In the database
                designEntity.customer_address.Add(newCustomerAddress);

                updatedRecord = designEntity.SaveChanges();

            }
            catch (Exception error)
            {

                System.Diagnostics.Debug.WriteLine("Error in Linq", error);
            }

        }

        //Changes the entity object, if it matches 
        else
        {

            customerMatches.CustShipAddr = theCustomer.CustShipAddr;

            customerMatches.CustShipCountry = theCustomer.CustShipCountry;

            customerMatches.CustShipState = theCustomer.CustShipState;

            customerMatches.CustShipCity = theCustomer.CustShipCity;

            customerMatches.CustShipPinCode = theCustomer.CustShipPinCode;


            try
            {
                //Finally commit the changes the changes and insert the record
                //In the database

                updatedRecord = designEntity.SaveChanges();

            }
            catch (Exception error)
            {

                System.Diagnostics.Debug.WriteLine("Error in Linq", error);
            }

        }

        //IF records get updated successfully
        if (updatedRecord > 0)
        {
            //Return this customerEntireData
            var customerEntireData = from cust in designEntity.customers
                                     join custAddr in designEntity.customer_address
                                     on cust.CustId equals custAddr.CustId
                                     where cust.CustId == theCustomer.CustId
                                     select new
                                     {
                                         cust.CustId,
                                         cust.CustFirstName,
                                         cust.CustLastName,
                                         cust.CustMobNo,
                                         cust.CustEmailAddr,
                                         cust.CustImg,

                                         custAddr.CustAddrId,
                                         custAddr.CustShipAddr,
                                         custAddr.CustShipCountry,
                                         custAddr.CustShipCity,
                                         custAddr.CustShipState,
                                         custAddr.CustShipPinCode

                                     };
            return Ok(customerEntireData);

        }
        return NotFound();

    }


    [Route("api/customer/escalateQuantity")]
    [HttpPut]                                                 //(productId), (customerId), (quantity)
    public IHttpActionResult IncreaseQuantity([FromBody] CartModel theCart)
    {
        designEntity = new online_tshirt_designingEntities();

        CartModel cartModel = new CartModel();

        ProductCartModel pc = new ProductCartModel();

        Product matchesProduct = designEntity.products

              .Where(prod => prod.ProductId == theCart.ProductId)//Where statement

              .Select(x => new Product
              {
                  ProductId = x.ProductId,
                  ProductCode = x.ProductCode,
                  ProductName = x.ProductName,
                  ProductStyle = x.ProductStyle,
                  ProductColor = x.ProductColor,
                  ProductImg = x.ProductImg,
                  ProductDisc = x.ProductDisc,
                  ProductPrice = (int)x.ProductPrice,
                  ProductSizeQuantM = (short)x.ProductSizeQuantM,
                  ProductSizeQuantXL = (short)x.ProductSizeQuantXL,
                  ProductSizeQuantXXL = (short)x.ProductSizeQuantXXL
              })
              .FirstOrDefault();


        //Sets the quantity
        cartModel.ProductQuantity = theCart.ProductQuantity;

        //Sets the price for selected individual product to be calculated
        cartModel.ProductQuantityPrice = matchesProduct.ProductPrice;


        //  cartModel.TotalProductPrice += matchesProduct.ProductPrice;

        return Ok(cartModel.ProductQuantityPrice);
    }

    [Route("api/customer/saveOrder")]
    [HttpPut]
    public IHttpActionResult SaveCustomerOrder([FromBody] IEnumerable<CartModel> theCart)
    {

        designEntity = new online_tshirt_designingEntities();

        //Takes each object
        foreach (CartModel item in theCart)
        {
            customer_order newOrder = new customer_order
            {
                ProductPaymentMthd = "cod",

                ProductQuantity = item.ProductQuantity,

                ProductQuantityPrice = item.ProductQuantityPrice,

                ProductSize = item.ProductSize,

                TotalPrice = item.TotalProductPrice,

                CustId = item.CustId,

                ProductId = item.ProductId
            };

            saveInEntity(newOrder);
        }

        //Returns the customer order
        var customerOrder = from order in designEntity.customer_order
                            join cust in designEntity.customers on order.CustId equals cust.CustId
                            join prod in designEntity.products on order.ProductId equals prod.ProductId
                            orderby order.ProductOrderTime
                            select new
                            {
                                order.ProductOrderTime,
                                order.ProductPaymentMthd,
                                order.ProductQuantity,
                                order.ProductQuantityPrice,
                                order.TotalPrice,

                                cust.CustFirstName,
                                cust.CustLastName,
                                cust.CustMobNo,
                                cust.CustEmailAddr,

                                prod.ProductCode,
                                prod.ProductCat,
                                prod.ProductName,
                                prod.ProductStyle,
                                prod.ProductColor,
                                prod.ProductImg,
                                prod.ProductPrice
                            };

        return Ok(customerOrder);

    }

    [NonAction]
    private void saveInEntity(customer_order newOrder)
    {
        try
        {
            //Finally commit the changes the changes and insert the record
            //In the database
            designEntity.customer_order.Add(newOrder);

            designEntity.SaveChanges();

        }
        catch (Exception error)
        {

            System.Diagnostics.Debug.WriteLine("Error in Linq", error);
        }
    }


    [Route("api/customer/getSavedOrder/{custId}")]
    [HttpGet]
    public IHttpActionResult SavedCustomerOrder(string custId)
    {
        designEntity = new online_tshirt_designingEntities();
        ////Returns the customer order
        var customerOrder = from order in designEntity.customer_order
                            join cust in designEntity.customers on order.CustId equals cust.CustId
                            join prod in designEntity.products on order.ProductId equals prod.ProductId
                            where order.CustId == custId
                            orderby order.ProductOrderTime
                            select new
                            {
                                order.ProductOrderTime,
                                order.ProductPaymentMthd,
                                order.ProductQuantity,
                                order.ProductQuantityPrice,
                                order.TotalPrice,
                                order.ProductSize,

                                cust.CustId,
                                cust.CustFirstName,
                                cust.CustLastName,
                                cust.CustMobNo,
                                cust.CustEmailAddr,

                                prod.ProductCode,
                                prod.ProductCat,
                                prod.ProductName,
                                prod.ProductStyle,
                                prod.ProductColor,
                                prod.ProductImg,
                                prod.ProductPrice
                            };

        return Ok(customerOrder);

    }


    // PUT api/<controller>/5
    [HttpPut]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [Route("api/customer/deleteAddr/{addrId}")]
    [HttpDelete]
    public IHttpActionResult DeleteCustomerAddress(string addrId)
    {
        //Sets the return result from SaveChanges()
        int deleted = 0;

        //Instantiate the obj
        designEntity = new online_tshirt_designingEntities();

        //Find an appropriate Customer Address

        //Execute the query and return the entity object 
        customer_address customerMatches = designEntity.customer_address.FirstOrDefault((c) => c.CustAddrId == addrId);

        if (customerMatches == null)
        {
            return NotFound();
        }
        //Excute the query and return the Object
        // customer_address customerMatchedAddrr = matches.Single();

        //Delete the record from the Database
        designEntity.customer_address.Remove(customerMatches);

        deleted = designEntity.SaveChanges();

        if (deleted > 0) return Ok(true);

        return NotFound();

    }


}
