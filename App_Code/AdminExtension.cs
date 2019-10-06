using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for AdminExtension
/// </summary>
public partial class admin
{

    public string UploadBannerFile(HttpPostedFileBase theBannerImageFile)
    {
        string uploadDirectory; // to save the file path where the folder has been created

        string databaseFilePath = "";

        // Create a new folder in your current directory 
        // to store the uplaoded images 
        string uploadedBlogs = "HomeBannerImages";

        uploadDirectory = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, uploadedBlogs);

        if (theBannerImageFile.FileName == "")
        {
            return "NoFileError";
        }
        else
        {
            // Check the extension of the file 
            string fileExtension = Path.GetExtension(theBannerImageFile.FileName);

            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".gif":
                    break;
                default:
                   // string.Format( "Invalid File Format");
     
                    return "FormatError"; // instead of break we used return directly which wont execute the below code
            }

            // Using this code , the saved file will retain its original 
            // file name when it's placed on the server.
            string serverFileName = Path.GetFileName(theBannerImageFile.FileName);

            //Content type like MIME such as .jpeg, .png
            string contentType = theBannerImageFile.ContentType;

            //Full path of folder UploadedBlogs with saved file name
            //This we are to store in the database to fetch the images 
            string fullUploadPath = Path.Combine(uploadDirectory, serverFileName);

            databaseFilePath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath;

            databaseFilePath += "HomeBannerImages/" + serverFileName;


            //We need to check that PostedFile objects's SaveAs method saves the file 
            //correctly or not

            try
            {
                theBannerImageFile.SaveAs(fullUploadPath);

            }
            catch (Exception e)
            {
                databaseFilePath = "SaveError";
            }
        }

        return databaseFilePath;
    }
}