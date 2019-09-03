using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;

/// <summary>
/// Summary description for Shopping
/// </summary>

public enum SelectionChoice
{
    Customer,
    Admin
}

[Serializable]
public class Shopping
{
    public string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["OnlineTshirtDesigning"].ConnectionString;

    public SelectionChoice objSelection;

    public int MyId { get; set; }

    private int sessionId;

    public string EmailId { get; set; }

    private string pwd;

    public string Name { get; set; }

    public double Price { get; set; }

    public int ProductId { get; set; }

    public string OrderTime { get; set; }

    public const ushort productInialCountl = 1; // to set the oroduct intial count 

    public ushort[] SizeQuantity; //for M , XL, XXL , Quantity 



    // Member methods 
    public string GetPwd
    {
        get
        {
            return pwd;
        }
        set
        {
            pwd = value;
        }
    }

    public bool Login()
    {
        HttpCookie cookie;

        string selectSqlQueryCust = "SELECT  CustId, CustEmailAddr, CustPwd FROM customer ";
        selectSqlQueryCust += "WHERE CustEmailAddr = @CustEmailAddr";

        string selectSqlQueryAdmin = "SELECT AdminId, AdminName,  AdminEmailAddr, AdminPwd FROM admin ";
        selectSqlQueryAdmin += "WHERE AdminEmailAddr = @AdminEmailAddr";

        bool readerResult = false;

        MySqlConnection connection = new MySqlConnection(connectionString);

        MySqlCommand cmd;

        MySqlDataAdapter adaptor;

        MySqlDataReader reader;

        if (objSelection == SelectionChoice.Customer)
        {
            cmd = new MySqlCommand(selectSqlQueryCust, connection);

            //Add the paramaters 
            cmd.Parameters.AddWithValue("@CustEmailAddr", EmailId);
            //  adaptor = new MySqlDataAdapter(cmd);
        }
        else
        {
            cmd = new MySqlCommand(selectSqlQueryAdmin, connection);

            //Add the parameters
            cmd.Parameters.AddWithValue("@AdminEmailAddr", EmailId);

            //  adaptor = new MySqlDataAdapter(cmd);
        }

        try
        {
            //To automatically dispose the connction Obj
            using (connection)
            {
                // Open the database connection
                connection.Open();
                reader = cmd.ExecuteReader();

                switch (objSelection)
                {
                    case SelectionChoice.Customer:

                        //Read the data from Customer table 
                        //If matches the given EmailId and password return true 
                        while (reader.Read())
                        {
                            if (EmailId == reader["CustEmailAddr"].ToString() && GetPwd == reader["CustPwd"].ToString())
                            {
                                MyId = Convert.ToInt32(reader["CustId"].ToString());

                                // Create the cookie 
                                cookie = new HttpCookie("CustomerInfo");

                                //Set value to cookie 
                                cookie["CustId"] = MyId.ToString();

                                //Add cookie to web browser with validaty
                                cookie.Expires = DateTime.Now.AddDays(2);
                                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                                //Navigate customer to home page 
                                //   System.Web.HttpContext.Current.Response.Redirect("Home.aspx");
                                readerResult = true;

                            }

                        }
                        break;

                    case SelectionChoice.Admin:

                        while (reader.Read())
                        {
                            if (EmailId == reader["AdminEmailAddr"].ToString() && GetPwd == reader["AdminPwd"].ToString())
                            {
                                MyId = Convert.ToInt32(reader["AdminId"]);

                                Name = reader["AdminName"].ToString();
                                // Create the cookie 
                                cookie = new HttpCookie("AdminInfo");

                                //Set value to cookie 
                                cookie["AdminId"] = MyId.ToString();
                                cookie["AdminName"] = Name;

                                //Add cookie to web browser with validaty
                                cookie.Expires = DateTime.Now.AddDays(2);
                                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                                ////Navigate customer to home page 
                                //System.Web.HttpContext.Current.Response.Redirect("AdminOrder.aspx");
                                readerResult = true;
                            }

                        }
                        break;

                    default:
                        break;
                }

            }

        }
        catch (Exception error)
        {
            Label errorLbl = new Label();
            System.Diagnostics.Debug.WriteLine("Database Error Message", error);
            errorLbl.Text = error.ToString();
        }
        return readerResult;
    }

    //if it implements in Admin, needs to override it
    //For other cookie

   
    virtual public void Logout()
    {
        HttpCookie cookie;
        //Get saved cookie
        cookie = System.Web.HttpContext.Current.Request.Cookies["CustomerInfo"];

        //Set cookie expire date 
        cookie.Expires = DateTime.Now.AddDays(-1);

        //Set cookie to the web 
        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

        //Navigate customer to home page 
        System.Web.HttpContext.Current.Response.Redirect("Home.aspx");

    }

    public Shopping()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //private decimal CalulateDiscountCost()
    //{

    //}
}