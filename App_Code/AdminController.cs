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
using System.Web;
using System.IO;

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

    // GET api/<controller>
    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("api/admin/homeBannerDetails")]
    public IHttpActionResult GetHomeBannerDetails()
    {
        designEntity = new online_tshirt_designingEntities();

        var entireHomeBanner = from ban in designEntity.home_banner1
                               orderby ban.BannerImgId
                               select ban;
        return Ok<IQueryable<home_banner1>>(entireHomeBanner);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("api/admin/changeBannerName")]
    public IHttpActionResult ChangeBannerName([FromBody]home_banner1 theBanner)
    {
        designEntity = new online_tshirt_designingEntities();

        //Matches the imageId and gives the matched row

        IQueryable<home_banner1> matches = designEntity.home_banner1.Where(x => x.BannerImgId == theBanner.BannerImgId).Select((x) => x);

        //Excutes the query and return the object

        home_banner1 newBannerNameChanges = matches.Single();

        //Updats the home banner obj
        newBannerNameChanges.BannerName = theBanner.BannerName;

        newBannerNameChanges.BannerDesc = theBanner.BannerDesc;
       
        //Commit the changes back to the database
        try
        {
           // designEntity.home_banner1.Add(newBannerNameChanges);

            designEntity.SaveChanges();

        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error);

        }

        var entireHomeBanner = from ban in designEntity.home_banner1
                               orderby ban.BannerImgId
                               select ban;
        return Ok<IEnumerable<home_banner1>>(entireHomeBanner);
        //  return Ok<string>("cool");
    }

    [HttpPost]
    [Route("api/admin/saveBannerDetails")]
    public HttpResponseMessage SaveBannerData()
    {
        //Gives the file at the position in File's array 
        int i = 0;

        //Counts the successfully uploaded files
        int count = 0;

        //Creates the list of uploaded files names
        List<string> uploadedFileNames = new List<string>();


        HttpResponseMessage response = new HttpResponseMessage();

        //Instantiates the entity obj
        designEntity = new online_tshirt_designingEntities();

        var httpRequest = HttpContext.Current.Request;

        //Checks the files, a one file is mandatory
        if (httpRequest.Files.Count > 0)
        {
            foreach (string file in httpRequest.Files)
            {
                HttpPostedFile postedFiles = httpRequest.Files[i];

                if (postedFiles.FileName == "")
                {
                    string fileMessage = string.Format("No file is selected for file {i}", i);

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, fileMessage);
                }

                // Check the extension of the file 
                string fileExtension = Path.GetExtension(postedFiles.FileName);

                switch (fileExtension.ToLower())
                {
                    case ".jpg":
                    case ".png":
                    case ".gif":
                        break;
                    default:
                        // string.Format( "Invalid File Format");
                        string formatMessage = string.Format("This file format is not supported");

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, formatMessage); ; // instead of break we used return directly which wont execute the below code
                }

                string filePath = HttpContext.Current.Server.MapPath("~/UploadedHomeBanner/" + postedFiles.FileName);

               string  databaseFilePath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath;

                databaseFilePath += "UploadedHomeBanner/" + postedFiles.FileName;

                try
                {
                    //Saves the file to the specified server path
                    postedFiles.SaveAs(filePath);

                    //Gives the saved files names at server directory(UploadedHomeBanner)

                    uploadedFileNames.Add(postedFiles.FileName);

                    //Updates the home_banner object 
                    home_banner1 newBannerChanges = new home_banner1
                    {

                        BannerImg = databaseFilePath,

                        BannerImgName = postedFiles.FileName

                    };

                    //Commit the changes back to the database
                    try
                    {
                        designEntity.home_banner1.Add(newBannerChanges);

                        designEntity.SaveChanges();

                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine(error);

                    }

                }
                catch (Exception ex)
                {

                    string fileSaveMessage = string.Format("The file size is high");

                    ex.Source = fileSaveMessage;

                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, fileSaveMessage, ex);

                }
                //Shifts to next file's Array position, if all good
                count = i++;
            }
        }

        var entireHomeBanner = from ban in designEntity.home_banner1
                               orderby ban.BannerImgId
                               select ban;


        HttpResponseMessage complition = Request.CreateResponse(HttpStatusCode.OK, entireHomeBanner);

        return complition;

        // return Request.CreateResponse(HttpStatusCode.OK);
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
