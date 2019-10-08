using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class CartController : ApiController
{
    online_tshirt_designingEntities designEntity;

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

    [Route("api/product/DeleteFromCart/{id}")]
    [HttpDelete]
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

    [Route("api/product/SwipeCart/{sessionID}/{custID}")]
    [HttpGet]
    public IHttpActionResult SwipeCart(string sessionID, string custID)
    {
        product prod = new product();

        //For Unique Id
        sbyte counter = 0;

        //Check the product 1st
        string pCartMatch = designEntity.product_cart.Where((p) => p.SessionId == sessionID).Select((p) => p.ProductCartId).SingleOrDefault();

        //If pCartMatch hasn't got any products
        if (String.IsNullOrEmpty(pCartMatch)) return Ok<bool>(true);

        //Save the product added in the ProductCart to CustomerProductCart 
        //if pCartMatch has got any products

        IEnumerable<product_cart> prodAddedCart = from p in designEntity.product_cart
                                                  where p.SessionId == sessionID
                                                  orderby p.ProductId
                                                  select p;

        //Creat List of CustomerProductCart to insert data 
        //from ProductCart to CustomerProductCart
        List<customer_product_cart> custProdCartList = designEntity.customer_product_cart.ToList();

        foreach (product_cart item in prodAddedCart)
        {
            custProdCartList.Add(new customer_product_cart()
            {
                CustCartId = (prod.DTime.Millisecond + counter++).ToString(),

                ProductId = item.ProductId,

                ProductCartId = item.ProductCartId,

                CustId = custID
            });
        }

        foreach (customer_product_cart item in custProdCartList)
        {
            designEntity.customer_product_cart.Add(item);
        }

        //Commit the changes back to the database
        try
        {
            designEntity.SaveChanges();
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error);

        }

        //var prodAddedToCustProdCart = from p in designEntity.products
        //                              join cp in designEntity.customer_product_cart
        //                              on p.ProductId equals 

        return Ok();
    }


    [Route("api/product/AddToCustomerProductCart/{productID}/{sessionID}/{custID}")]
    [HttpPost]
    public IHttpActionResult AddToCustomerProductCart([FromUri] sbyte productID, string custID)
    {
        designEntity = new online_tshirt_designingEntities();

        product prod = new product();

        customer_product_cart newCustomerProdCart;

        //1st check the product_cart table if it has got any added products

        //var pCartMatch = (from p in designEntity.product_cart
        //                  where p.ProductId == productID && p.SessionId == sessionID
        //                  select p.ProductCartId);

        //string x =  pCartMatch.SingleOrDefault();

        string pCartMatch = designEntity.customer_product_cart.Where((p) => p.ProductId == productID && p.CustId == custID).Select((p) => p.ProductId.ToString()).SingleOrDefault();

        //If pCartMatch hasn't got any products i.e string is empty or null
        if (String.IsNullOrEmpty(pCartMatch))
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


            //Return the products added in the cart
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

        //If pCart has got the product
        return Ok<string>("The Product has already been added in the cart");

    }


    [Route("api/product/ShowProductCart/{sessionID}")]
    [HttpGet]
    public IHttpActionResult ShowProductCart(string sessionID)
    {
        //Return the products added in the cart
        var productCart = from entProd in designEntity.products
                          join entCart in designEntity.product_cart
                          on entProd.ProductId equals entCart.ProductId
                          where entCart.SessionId == sessionID

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
        return Ok(productCart);
    }

    [Route("api/product/ShowCustomerCart/{custID}")]
    [HttpGet]
    public IHttpActionResult ShowCustomerCart(string custID)
    {
        //Return the products added in the cart
        var customerProductCart = from entProd in designEntity.products
                                  join entCart in designEntity.customer_product_cart
                                  on entProd.ProductId equals entCart.ProductId
                                  where entCart.CustId == custID

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
        return Ok(customerProductCart);
    }

    [Route("api/product/DeleteFromCart/{productID}/{custID}")]
    [HttpGet]
    public void DeleteFromCustomerCart(sbyte productID, string custID)
    {

        designEntity = new online_tshirt_designingEntities();

        var matches = from p in designEntity.customer_product_cart
                      where p.ProductId == productID && p.CustId == custID
                      select p;

        //Execute the Query & return the Obj
        customer_product_cart pCart = matches.Single();

        //Delete the Record from the Database
        designEntity.customer_product_cart.Remove(pCart);
        designEntity.SaveChanges();

    }

}
