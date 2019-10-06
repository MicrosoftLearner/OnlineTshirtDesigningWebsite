using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HomeBannerModel
/// </summary>
public class HomeBannerModel

{
    
    public HttpPostedFileBase BannerImageFile { get; set; }

    public string BannerName { get; set; }

    public string BannerDesc { get; set; }

    public string BannerImgName { get; set; }

}