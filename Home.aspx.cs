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
    protected void Page_Load(object sender, EventArgs e)
    {
        // If this page is being viewed 1st time in the browser 
        if (!this.IsPostBack)
        {
            FillHomeBanner();
            FillUserBlogs();

            //Check for cookie 
            //  CheckForCookie();

        }

        else System.Diagnostics.Debug.WriteLine("Its not the 1st time");
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
                    RepeatBlogData.DataSource = dt;
                    RepeatBlogData.DataBind();
                }
            }
        }
        catch (Exception error)
        {

            LblDatabaseError.Text = error.ToString();
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
                    RepeatHomeBannerData.DataSource = dt;
                    RepeatHomeBannerData.DataBind();
                }
            }
        }
        catch (Exception error)
        {

            LblDatabaseError.Text = error.ToString();
        }
    }

    protected void RepeatHomeBannerData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        byte[] bytes = (byte[])(e.Item.DataItem as DataRowView)["HomeImg"];
        string base64Srting = Convert.ToBase64String(bytes, 0, bytes.Length);
        (e.Item.FindControl("SliderHomeBannerImg") as Image).ImageUrl = "data:image/png;base64," + base64Srting;
    }
}