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
    online_tshirt_designingEntities1 design;

    // GET api/<controller>
    [HttpGet]
    public HttpResponseMessage GetProductDtls()
    {
        //Instansitiate Obj
          design = new online_tshirt_designingEntities1();

        //Set the appropriate Objec's fields in 
         var entireProd = from prod in design.products select new { prod.ProductId , prod.ProductCode, prod.ProductCat, prod.ProductName, prod.ProductStyle, prod.ProductColor, prod.ProductImg, prod.ProductPrice, prod.ProductNewArrival, prod.ProductSizeQuantM, prod.ProductSizeQuantXL, prod.ProductSizeQuantXXL };

        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, entireProd);

        return  response;
    }

    // GET api/<controller>/5
    [HttpGet]
    public HttpResponseMessage GetIndividualProdcut(int id)
    {
        //Instansitiate Obj
        design = new online_tshirt_designingEntities1();

        var indProd = from prod in design.products where prod.ProductId == id select new { prod.ProductId, prod.ProductCode, prod.ProductCat, prod.ProductName, prod.ProductStyle, prod.ProductColor, prod.ProductImg, prod.ProductDisc, prod.ProductPrice, prod.ProductNewArrival, prod.ProductSizeQuantM, prod.ProductSizeQuantXL, prod.ProductSizeQuantXXL };

        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, indProd);
        
        return response;
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
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
