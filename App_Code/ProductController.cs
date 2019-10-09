using System;
using System.Collections.Generic;
using System.Net;

using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
public class ProductController : ApiController
{

    online_tshirt_designingEntities designEntity;

    // GET api/<controller>

    [Route("api/product/getProducts")]
    [HttpGet]
    public HttpResponseMessage GetProducts()
    {
        //Instansitiate Obj
        designEntity = new online_tshirt_designingEntities();

        // System.Web.HttpContext.Current.Session[""] = "";

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
                             //  SessionID = System.Web.HttpContext.Current.Session.SessionID
                         };

        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, entireProd);
        //  return Ok(new Tuple<object, string>(entireProd, "sidd"));

        return response;
    }

    [Route("api/product/getIndividualProduct/{id}")]
    [HttpGet]
    public HttpResponseMessage GetProduct(int id)
    {
        //Instansitiate Obj

        designEntity = new online_tshirt_designingEntities();

        Product individualProdModel = designEntity.products.Where(find => find.ProductId == id).Select(x => new Product
        {
            ProductId = x.ProductId,
            ProductCode = x.ProductCode,
            ProductCat = x.ProductCat,
            ProductName = x.ProductName,
            ProductStyle = x.ProductStyle,
            ProductColor = x.ProductColor,
            ProductImg = x.ProductImg,
            ProductDisc = x.ProductDisc,
            ProductPrice = (int)x.ProductPrice,
            ProductNewArrival = x.ProductNewArrival,
            ProductSizeQuantM = (short)x.ProductSizeQuantM,
            ProductSizeQuantXL = (short)x.ProductSizeQuantXL,
            ProductSizeQuantXXL = (short)x.ProductSizeQuantXXL
        }).FirstOrDefault();


        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, individualProdModel);

        return response;
    }

    [Route("api/product/getHomeBannerProducts")]
    [HttpGet]
    public IHttpActionResult HomeBannerProducts()
    {
        designEntity = new online_tshirt_designingEntities();

        IQueryable<home_banner1> entireBanner = designEntity.home_banner1.Select((x) => x);
        
        return Ok(entireBanner);
    }

    [Route("api/product/getBlogs")]
    [HttpGet]
    public IHttpActionResult ShowBlogs()
    {
        designEntity = new online_tshirt_designingEntities();

        IQueryable<inner_blogs> entireBlogs = designEntity.inner_blogs.Select((x) => x);

        return Ok(entireBlogs);
    }

    [Route("api/product/getBlogs/id")]
    [HttpGet]
    public inner_blogs ShowBlogs(int id)
    {
        designEntity = new online_tshirt_designingEntities();

        inner_blogs individualBlogs = designEntity.inner_blogs.Where(blog => blog.InnerBlogsId == id).Select((x) => x).First();

        return individualBlogs;
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

}

