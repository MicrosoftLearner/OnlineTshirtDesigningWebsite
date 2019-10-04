using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HomeBannerModel
/// </summary>
public class HomeBannerModel

{
    public short InnerBlogsId { get; set; }

    public string InnerBlogsImg { get; set; }

    public string InnerBlogsImgName { get; set; }

    public string InnerBlogsName { get; set; }

    public string InnerBlogsDesc { get; set; }

    public HttpPostedFileBase BannerImageFile { get; set; }

}