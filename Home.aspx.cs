using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;

public partial class Home : System.Web.UI.Page
{
    HttpCookie cookie;

    Customer cust;

    Product prod;

    List<Product> homeProd;

    protected void Page_Load(object sender, EventArgs e)
    {
        // If this page is being viewed 1st time in the browser 
        if (!this.IsPostBack)
        {
           // FillHomeBanner();

           // FillUserBlogs();

           // GetProducts();
            //Check for cookie 
            //  CheckForCookie();

        }

        if (this.IsPostBack)
        {
            homeProd = (List<Product>) ViewState["ProductList"];
        }

        else System.Diagnostics.Debug.WriteLine("Its not the 1st time");
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        //Store List collection in ViewState 
        ViewState["ProductList"] = homeProd;
    }

    private void GetProducts()
    {
        //Initialize the Obj
        prod = new Product();

        homeProd = new List<Product>();

        //Check ProductList is in view state or not 
        if (ViewState["ProductList"] == null)
        {
            ViewState["ProductList"] = homeProd;
        }

        // Define Ado.Net object
        string selectSQL = "SELECT ProductId, ProductCode, ProductCat, ProductName, ProductStyle, ProductColor, ProductImg, ProductDisc, ProductPrice, ProductNewArrival, ProductSizeQuantM, ProductSizeQuantXL, ProductSizeQuantXXL FROM product";
  
        MySqlConnection connection = new MySqlConnection(Master.connectionString);

        MySqlCommand cmd = new MySqlCommand(selectSQL, connection);

        MySqlDataReader homeProdReader;

        try
        {
            using (connection)
            {
                // Open database connection 
                connection.Open();

                homeProdReader = cmd.ExecuteReader();
    

                while (homeProdReader.Read())
                {
                    homeProd.Add(new Product()
                    {

                        ProductId = Convert.ToInt16(homeProdReader["ProductId"].ToString().Trim()),

                        ProductCode = homeProdReader["ProductCode"].ToString().Trim(),

                        ProductCat = homeProdReader["ProductCat"].ToString().Trim(),

                        ProductName = homeProdReader["ProductName"].ToString().Trim(),

                        ProductStyle = homeProdReader["ProductStyle"].ToString().Trim(),

                        ProductColor = homeProdReader["ProductColor"].ToString().Trim(),

                        ProductImg = homeProdReader["ProductImg"].ToString().Trim(),

                        //ProductDesc = homeProdReader["ProductDisc"].ToString().Trim(),

                        ProductPrice = Convert.ToInt16(homeProdReader["ProductPrice"].ToString().Trim()),

                        ProductNewArrival = homeProdReader["ProductNewArrival"].ToString().Trim(),

                        //SizeQuantity = new ushort[3] {
                        //    Convert.ToUInt16(homeProdReader["ProductSizeQuantM"].ToString().Trim()), //M
                        //    Convert.ToUInt16(homeProdReader["ProductSizeQuantXL"].ToString().Trim()), //XL
                        //    Convert.ToUInt16(homeProdReader["ProductSizeQuantXXL"].ToString().Trim()), //XXL
                        //}

                    });


                }

            }
        }

        catch (Exception error)
        {

           
        }
        
        //Show Fetched Product data from database  to the Slider 
    //    RepeatNewArrivalData.DataSource = homeProd;

        //Bind data
     //   RepeatNewArrivalData.DataBind();
    }

    private void FillUserBlogs()
    {
        // Define Ado.Net object

        string selectSQL = "SELECT * FROM inner_blogs";
        DataTable dt = new DataTable();
        MySqlConnection connection = new MySqlConnection(Master.connectionString);
        MySqlCommand cmd = new MySqlCommand(selectSQL, connection);
        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

        try
        {
            using (connection)
            {
                // Open database connection 
                connection.Open();
                // Fill the Data to DataAdaptor
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                  //  RepeatBlogData.DataSource = dt;
                   // RepeatBlogData.DataBind();
                }
            }
        }
        catch (Exception error)
        {

           //LblDatabaseError.Text = error.ToString();
        }
    }

    // to fill homebanner content directly from database
    private void FillHomeBanner()
    {
        // Define Ado.Net object

        string selectSQL = "SELECT * FROM home_banner";
        DataTable dt = new DataTable();
        MySqlConnection connection = new MySqlConnection(Master.connectionString);
        MySqlCommand cmd = new MySqlCommand(selectSQL, connection);
        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

        try
        {
            using (connection)
            {
                // Open database connection 
                connection.Open();
                // Fill the Data to DataAdaptor
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //RepeatHomeBannerData.DataSource = dt;
                    //RepeatHomeBannerData.DataBind();
                }
            }
        }
        catch (Exception error)
        {

           // LblDatabaseError.Text = error.ToString();
        }
    }

    protected void RepeatHomeBannerData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        byte[] bytes = (byte[])(e.Item.DataItem as DataRowView)["HomeImg"];
        string base64Srting = Convert.ToBase64String(bytes, 0, bytes.Length);
        (e.Item.FindControl("SliderHomeBannerImg") as Image).ImageUrl = "data:image/png;base64," + base64Srting;
    }

    protected void ButtonFeaturedBuyNow_Command(object sender, CommandEventArgs e)
    {
        string url = "~/Products/IndividualProduct.aspx?";

        //Filter appropriate data based on 
        //Clicked product
        IEnumerable<Product> appropProd = from x in homeProd where x.ProductId == Convert.ToInt32(e.CommandArgument) select x;

        //Redirect url
        foreach (Product item in appropProd)
        {
            url += "prodId=" + Server.UrlEncode(item.ProductId.ToString()) + "&";

            url += "prodCode=" + Server.UrlEncode(item.ProductCode.ToString()) + "&";

            url += "prodCat=" + Server.UrlEncode(item.ProductCat.ToString()) + "&";

            url += "prodName=" + Server.UrlEncode(item.ProductName.ToString()) + "&";

            url += "prodStyle=" + Server.UrlEncode(item.ProductStyle.ToString()) + "&";

            url += "prodColor=" + Server.UrlEncode(item.ProductColor.ToString()) + "&";

            url += "prodImg=" + Server.UrlEncode(item.ProductImg.ToString()) + "&";

       //     url += "prodDesc=" + Server.UrlEncode(item.ProductDesc.ToString()) + "&";

            url += "prodPrice=" + Server.UrlEncode(item.ProductPrice.ToString()) + "&";
            
        }

        //Redirect to IndividualProduct page 
        Response.Redirect(url);

    }
}