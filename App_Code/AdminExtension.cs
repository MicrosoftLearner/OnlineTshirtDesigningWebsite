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

    public string UploadBanner(HomeBannerModel bannerData)
    {
        string uploadDirectory; // to save the file path where the folder has been created

        string databaseFilePath;

        // Create a new folder in your current directory 
        // to store the uplaoded images 
        string uploadedBlogs = "UploadedBlogsImages";

        uploadDirectory = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, uploadedBlogs);

        if (bannerData.BannerImageFile.FileName == "")
        {
            return "No file";
        }
        else
        {
            // Check the extension of the file 
            string fileExtension = Path.GetExtension(bannerData.BannerImageFile.FileName);

            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".gif":
                    break;
                default:
                    string.Format( "Invalid File Format");
     
                    return "Invalid File Format"; // instead of break we used return directly which wont execute the below code
            }

            // Using this code , the saved file will retain its original 
            // file name when it's placed on the server.
            string serverFileName = Path.GetFileName(bannerData.BannerImageFile.FileName);

            //Content type like MIME such as .jpeg, .png
            string contentType = bannerData.BannerImageFile.ContentType;

            //Full path of folder UploadedBlogs with saved file name
            //This we are to store in the database to fetch the images 
            string fullUploadPath = Path.Combine(uploadDirectory, serverFileName);

            databaseFilePath = "~/UploadedBlogsImages/" + serverFileName;

            //remaining file save method
          
        }
        return databaseFilePath;
    }
}