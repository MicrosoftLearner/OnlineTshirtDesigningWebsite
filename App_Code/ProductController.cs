using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

public class ProductController : ApiController
{

    online_tshirt_designingEntities designEntity;

    // GET api/<controller>
    [HttpGet]
    public HttpResponseMessage GetProductDtls()
    {
        //Instansitiate Obj
        designEntity = new online_tshirt_designingEntities();

        //Set the appropriate Objec's fields in 
        var entireProd = from prod in designEntity.products
                         select new
                         {
                             prod.ProductId,
                             prod.ProductCode,
                             prod.ProductCat,
                             prod.ProductName,
                             prod.ProductStyle,
                             prod.ProductColor,
                             prod.ProductImg,
                             prod.ProductPrice,
                             prod.ProductNewArrival,
                             prod.ProductSizeQuantM,
                             prod.ProductSizeQuantXL,
                             prod.ProductSizeQuantXXL,
                             SessionID = System.Web.HttpContext.Current.Session.SessionID
                         };

        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, entireProd);

        return response;
    }

    // GET api/<controller>/5
    [HttpGet]
    public HttpResponseMessage GetIndividualProdcut(int id)
    {
        //Instansitiate Obj
        designEntity = new online_tshirt_designingEntities();

        var indProd = from prod in designEntity.products
                      where prod.ProductId == id
                      select new
                      {
                          prod.ProductId,
                          prod.ProductCode,
                          prod.ProductCat,
                          prod.ProductName,
                          prod.ProductStyle,
                          prod.ProductColor,
                          prod.ProductImg,
                          prod.ProductDisc,
                          prod.ProductPrice,
                          prod.ProductNewArrival,
                          prod.ProductSizeQuantM,
                          prod.ProductSizeQuantXL,
                          prod.ProductSizeQuantXXL
                      };

        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, indProd);

        return response;
    }

    // POST api/<controller>
    [HttpPost]
    [Route("api/product/AddToCart/{id}/{sessionID}")]
    public IHttpActionResult AddToCart([FromUri] sbyte id, string sessionID)
    {

        designEntity = new online_tshirt_designingEntities();

        //1st check the Product is already in cart or not  
        var matchesCart = designEntity.product_cart.Where((c) => c.ProductId == id && c.SessionId == sessionID).Select((c) => c.ProductCartId).FirstOrDefault();

        if (matchesCart != null) return Ok<string>("Product is already added in the cart");

        //If product is not added in the cart
        product prod = new product();


        //Change the  ProductCart obj 
        product_cart pdCart = new product_cart
        {

            ProductCartId = prod.DTime.Millisecond.ToString(),

            ProductId = id,

            SessionId = sessionID

        };

        //Commit the changes back to the database
        try
        {
            designEntity.product_cart.Add(pdCart);
            designEntity.SaveChanges();
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error);

        }


        //Return the product added in the cart
        var cart = from entProd in designEntity.products
                   join entCart in designEntity.product_cart
                   on entProd.ProductId equals entCart.ProductId
                   where entCart.ProductId == id
                   select new
                   {
                       //Send entire product Obj
                       entProd.ProductId,
                       entProd.ProductCode,
                       entProd.ProductCat,
                       entProd.ProductName,
                       entProd.ProductStyle,
                       entProd.ProductColor,
                       entProd.ProductImg,
                       entProd.ProductDisc,
                       entProd.ProductPrice,
                       entProd.ProductSizeQuantM,
                       entProd.ProductSizeQuantXL,
                       entProd.ProductSizeQuantXXL,
                       //Send product_cart's Objects properties
                       ProductCartID = entCart.ProductCartId,
                       ProductID = entCart.ProductId,
                       SessionID = entCart.SessionId

                   };

        return Ok(Tuple.Create(cart, false));
    }


    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    [Route("api/product/DeleteFromCart/{id}")]
    [HttpGet]
    public void DeleteFromCart(sbyte id)
    {

        designEntity = new online_tshirt_designingEntities();

        var matches = from p in designEntity.product_cart
                      where p.ProductId == id
                      select p;

        //Execute the Query & return the Obj
        product_cart pCart = matches.Single();

        //Delete the Record from the Database
        designEntity.product_cart.Remove(pCart);
        designEntity.SaveChanges();

    }

    [Route("api/product/AddToCustomerProductCart/{productID}/{sessionID}/{custID}")]
    [HttpPost]
    public IHttpActionResult AddToCustomerProductCart([FromUri] sbyte productID, string sessionID, string custID)
    {
        designEntity = new online_tshirt_designingEntities();

        product prod = new product();

        customer_product_cart newCustomerProdCart;

        //1st check the product_cart table if it has got any added products
        IEnumerable<product_cart> pCartMatch = from p in designEntity.product_cart
                                               where p.ProductId == productID && p.SessionId == sessionID
                                               select p;

        var x = (from p in designEntity.product_cart
                 where p.ProductId == productID && p.SessionId == sessionID
                 select p.ProductCartId);
        x.SingleOrDefault();



        //If pCart hasn't got any products
        if (pCartMatch.Count() == 0)
        {

            newCustomerProdCart = new customer_product_cart
            {
                CustCartId = prod.DTime.Millisecond.ToString(),

                ProductId = productID,

                ProductCartId = null,

                CustId = custID
            };

            //Commit the changes back to the database
            try
            {
                designEntity.customer_product_cart.Add(newCustomerProdCart);
                designEntity.SaveChanges();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error);

            }


            //Return the product added in the cart
            var cart = from entProd in designEntity.products
                       join entCart in designEntity.customer_product_cart
                       on entProd.ProductId equals entCart.ProductId
                       where entCart.ProductId == productID && entCart.CustId == custID
                       select new
                       {
                           //Send entire product Obj
                           entProd.ProductId,
                           entProd.ProductCode,
                           entProd.ProductCat,
                           entProd.ProductName,
                           entProd.ProductStyle,
                           entProd.ProductColor,
                           entProd.ProductImg,
                           entProd.ProductDisc,
                           entProd.ProductPrice,
                           entProd.ProductSizeQuantM,
                           entProd.ProductSizeQuantXL,
                           entProd.ProductSizeQuantXXL,
                           //Send product_cart's Objects properties
                           ProductCartID = entCart.ProductCartId,
                           ProductID = entCart.ProductId

                       };
            return Ok(cart);
        }

     
           newCustomerProdCart = new customer_product_cart
            {
                CustCartId = prod.DTime.Millisecond.ToString(),

                ProductId = productID,

                ProductCartId = x.SingleOrDefault(),

                CustId = custID
            };
        

        //Commit the changes back to the database
        try
        {
            designEntity.customer_product_cart.Add(newCustomerProdCart);
            designEntity.SaveChanges();
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error);

        }

    }
}
