using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Http;
using System.Web.Http.Cors;

[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
public class CartController : ApiController
{
    online_tshirt_designingEntities designEntity;

    // POST api/<controller>
    [Route("api/cart/addToCart")]
    [HttpPut]
    public IHttpActionResult AddToCart([FromBody] CartModel theCart )
    {

        designEntity = new online_tshirt_designingEntities();

        int insertedRecord = 0;

        //1st checks the Product is already in cart or not  
        var matchesCart =  designEntity.products//from statement
            .Join(designEntity.product_cart, //Source table of inner join

                  prod => prod.ProductId,  //Select the primarykey (the first part of the "on" clause in an sql "join" statement)

                  cart => cart.ProductId,//Select the foreign key i.e on clause

                  (prod, cart) => new { Prod = prod, Cart = cart } //Selection
                    )
              .Where(cart => (cart.Cart.ProductId == theCart.ProductId) && (cart.Cart.CustId == theCart.CustId))//Where statement

              .FirstOrDefault();

       
            //designEntity.product_cart.FirstOrDefault((c) => c.ProductId == theCart.ProductId && c.CustId == theCart.CustId) ;

        int cartLength = designEntity.product_cart.Select((c) => c).Where(c => c.CustId == theCart.CustId).Count();

        //It states the product is in the cart
        if (matchesCart != null) return NotFound();

        //Inserts in the Entity database, if no product is added
        product_cart newCartEntry = new product_cart
        {
            ProductQuantity = theCart.ProductQuantity,

            ProductQuantityPrice = theCart.ProductQuantityPrice,

            ProductId = theCart.ProductId,
            
            CustId = theCart.CustId
        };

        try
        {
            //Commits the changes  and inserts the record
            //In Entity database
            designEntity.product_cart.Add(newCartEntry);

            insertedRecord = designEntity.SaveChanges();

        }
        catch (Exception error)
        {

            System.Diagnostics.Debug.WriteLine("Error in Linq", error);
        }

        if (insertedRecord > 0)
         return Ok(cartLength);

        return NotFound();
     
    }

    [Route("api/cart/getCart/{custId}")]
    [HttpGet]
    public IHttpActionResult GetCart(string custId)
    {
        CartModel cartModel = new CartModel();

        designEntity = new online_tshirt_designingEntities();

  
        //Return the product added in the cart
        var cart = from entProd in designEntity.products

                   join entCart in designEntity.product_cart

                   on entProd.ProductId equals entCart.ProductId

                   where entCart.CustId == custId

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
                    //   entProd.ProductPrice,
                       entProd.ProductSizeQuantM,
                       entProd.ProductSizeQuantXL,
                       entProd.ProductSizeQuantXXL,

                       entCart.ProductCartId,
                       entCart.ProductQuantity,
                       entCart.ProductQuantityPrice
                   
                   };

        //Calculates the price 
       
        foreach (var item in cart)
        {
           cartModel.ProductQuantityPrice = (int)item.ProductQuantityPrice;

        }

        return Ok(new Tuple<IEnumerable<object>, double>(cart, cartModel.ProductQuantityPrice));
    }

    [Route("api/cart/escalateQuantity")]
    [HttpPut]                                                 //(productId), (customerId), (quantity)
    public IHttpActionResult IncreaseQuantity([FromBody] Tuple<short, string, short> paramsToCalculate)
    {
        designEntity = new online_tshirt_designingEntities();

        CartModel cartModel = new CartModel();

        ProductCartModel pc = new ProductCartModel();

        int updatedRecord = 0;

        var matchesProduct = designEntity.products//from statement
            .Join(designEntity.product_cart, //Source table of inner join

                  prod => prod.ProductId,  //Select the primarykey (the first part of the "on" clause in an sql "join" statement)

                  cart => cart.ProductId,//Select the foreign key i.e on clause

                  (prod, cart) => new {Prod = prod, Cart = cart } //Selection
                    )
              .Where(cart => (cart.Cart.ProductId == paramsToCalculate.Item1) && (cart.Cart.CustId == paramsToCalculate.Item2) )//Where statement

              .FirstOrDefault();

        
        //Sets the quantity 
        cartModel.ProductQuantity = paramsToCalculate.Item3;

        //Sets the price for selected individual product to be calculated
        cartModel.ProductQuantityPrice = (int)matchesProduct.Prod.ProductPrice;

        //Change the entity object
        product_cart newProductCartEntry = matchesProduct.Cart;

        newProductCartEntry.ProductQuantityPrice = cartModel.ProductQuantityPrice;

       
        try
        {
            //Commits the changes  and inserts the record
            //In Entity database
         
            updatedRecord = designEntity.SaveChanges();

        }
        catch (Exception error)
        {

            System.Diagnostics.Debug.WriteLine("Error in Linq", error);
        }

        if (updatedRecord > 0)
        {
            //Return the product added in the cart
            var cart = from entProd in designEntity.products

                       join entCart in designEntity.product_cart

                       on entProd.ProductId equals entCart.ProductId

                       where entCart.CustId == paramsToCalculate.Item2

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

                           entCart.ProductCartId,
                           entCart.ProductQuantity,
                           entCart.ProductQuantityPrice

                       };

            return Ok(cart);
        }

        return NotFound();
    }



    [Route("api/product/deleteCart/{productId}")]
    [HttpDelete]
    public IHttpActionResult DeleteFromCart(short productId)
    {

        designEntity = new online_tshirt_designingEntities();

        var matches = from p in designEntity.product_cart
                      where p.ProductId == productId
                      select p;

        //Execute the Query & return the Obj
        product_cart pCart = matches.Single();

        //Delete the Record from the Database
        designEntity.product_cart.Remove(pCart);
        designEntity.SaveChanges();

        return Ok();
    }


    [Route("api/product/getPrice")]
    [HttpPost]
    public IHttpActionResult GetPrice(short productId)
    {
        return Ok();
    }


    [Route("api/product/SwipeCart/{sessionID}/{custID}")]
    [HttpGet]
    public IHttpActionResult SwipeCart(string sessionID, string custID)
    {
        //product prod = new product();

        ////For Unique Id
        //sbyte counter = 0;

        ////Check the product 1st
        //string pCartMatch = designEntity.product_cart.Where((p) => p.ProductId.ToString() == sessionID).Select((p) => p.ProductCartId).SingleOrDefault();

        ////If pCartMatch hasn't got any products
        //if (String.IsNullOrEmpty(pCartMatch)) return Ok<bool>(true);

        ////Save the product added in the ProductCart to CustomerProductCart 
        ////if pCartMatch has got any products

        //IEnumerable<product_cart> prodAddedCart = from p in designEntity.product_cart
                                                
        //                                          orderby p.ProductId
        //                                          select p;

        ////Creat List of CustomerProductCart to insert data 
        ////from ProductCart to CustomerProductCart
        //List<customer_product_cart> custProdCartList = designEntity.customer_product_cart.ToList();

        //foreach (product_cart item in prodAddedCart)
        //{
        //    custProdCartList.Add(new customer_product_cart()
        //    {
        //        CustCartId = (prod.DTime.Millisecond + counter++).ToString(),

        //        ProductId = item.ProductId,

        //        ProductCartId = item.ProductCartId,

        //        CustId = custID
        //    });
        //}

        //foreach (customer_product_cart item in custProdCartList)
        //{
        //    designEntity.customer_product_cart.Add(item);
        //}

        ////Commit the changes back to the database
        //try
        //{
        //    designEntity.SaveChanges();
        //}
        //catch (Exception error)
        //{
        //    System.Diagnostics.Debug.WriteLine(error);

        //}

        ////var prodAddedToCustProdCart = from p in designEntity.products
        ////                              join cp in designEntity.customer_product_cart
        ////                              on p.ProductId equals 

      return Ok();
    }


    [Route("api/product/AddToCustomerProductCart/{productID}/{sessionID}/{custID}")]
    [HttpPost]
    public IHttpActionResult AddToCustomerProductCart([FromUri] sbyte productID, string custID)
    {
        //designEntity = new online_tshirt_designingEntities();

        //product prod = new product();

        //customer_product_cart newCustomerProdCart;

        ////1st check the product_cart table if it has got any added products

        ////var pCartMatch = (from p in designEntity.product_cart
        ////                  where p.ProductId == productID && p.SessionId == sessionID
        ////                  select p.ProductCartId);

        ////string x =  pCartMatch.SingleOrDefault();

        //string pCartMatch = designEntity.customer_product_cart.Where((p) => p.ProductId == productID && p.CustId == custID).Select((p) => p.ProductId.ToString()).SingleOrDefault();

        ////If pCartMatch hasn't got any products i.e string is empty or null
        //if (String.IsNullOrEmpty(pCartMatch))
        //{

        //    newCustomerProdCart = new customer_product_cart
        //    {
        //        CustCartId = prod.DTime.Millisecond.ToString(),

        //        ProductId = productID,

        //        ProductCartId = null,

        //        CustId = custID
        //    };

        //    //Commit the changes back to the database
        //    try
        //    {
        //        designEntity.customer_product_cart.Add(newCustomerProdCart);
        //        designEntity.SaveChanges();
        //    }
        //    catch (Exception error)
        //    {
        //        System.Diagnostics.Debug.WriteLine(error);

        //    }


        //    //Return the products added in the cart
        //    var cart = from entProd in designEntity.products
        //               join entCart in designEntity.customer_product_cart
        //               on entProd.ProductId equals entCart.ProductId
        //               where entCart.ProductId == productID && entCart.CustId == custID
        //               select new
        //               {
        //                   //Send entire product Obj
        //                   entProd.ProductId,
        //                   entProd.ProductCode,
        //                   entProd.ProductCat,
        //                   entProd.ProductName,
        //                   entProd.ProductStyle,
        //                   entProd.ProductColor,
        //                   entProd.ProductImg,
        //                   entProd.ProductDisc,
        //                   entProd.ProductPrice,
        //                   entProd.ProductSizeQuantM,
        //                   entProd.ProductSizeQuantXL,
        //                   entProd.ProductSizeQuantXXL,
        //                   //Send product_cart's Objects properties
        //                   ProductCartID = entCart.ProductCartId,
        //                   ProductID = entCart.ProductId

        //               };
        //    return Ok(cart);
        //}

        //If pCart has got the product
        return Ok<string>("The Product has already been added in the cart");

    }

    /// <summary>
    /// Its for Session based
    /// </summary>
    /// <param name="sessionID"></param>
    /// <returns></returns>
    [Route("api/product/ShowProductCart/{sessionID}")]
    [HttpGet]
    public IHttpActionResult ShowProductCart(string sessionID)
    {
        //Return the products added in the cart
        var productCart = from entProd in designEntity.products
                          join entCart in designEntity.product_cart
                          on entProd.ProductId equals entCart.ProductId
                         // where entCart.SessionId == sessionID

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
  
}
