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

 public class Shopping
{
    protected string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["OnlineTshirtDesigning"].ConnectionString;

    public SelectionChoice objSelection;

    protected int MyId { get; set; }

    private int sessionId;

    public string EmailId { get; set; }

    private string pwd;

    public string Name { get; set; }

    public double Price { get; set; }

    public int ProductId { get; set; }

    public string OrderTime { get; set; }

    public const ushort productInialCountl = 1; // to set the oroduct intial count  

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

    public int Login
    {
        get
        {
            string selectSqlQueryCust = "SELECT  CustId, CustEmail, CustPwd FROM customer";
            selectSqlQueryCust += "WHERE CustEmailAddr = @CustEmailAddr";

            string selectSqlQueryAdmin = "SELECT AdminId, AdminEmail, AdminPwd FROM Admin";
            selectSqlQueryAdmin += "WHERE AdminEmailAddr = @AdminEmailAddr";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd;

            MySqlDataAdapter adaptor;

            MySqlDataReader reader;

            if (objSelection == SelectionChoice.Customer)
            {
                cmd = new MySqlCommand(selectSqlQueryCust, connection);

                //Add the paramaters 
                cmd.Parameters.AddWithValue("@CustEmailAddr", EmailId);
                adaptor = new MySqlDataAdapter(cmd);
            }
            else
            {
                cmd = new MySqlCommand(selectSqlQueryAdmin, connection);

                //Add the parameters
                cmd.Parameters.AddWithValue("@AdminEmailAddr", EmailId);

                adaptor = new MySqlDataAdapter(cmd);
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
                                if ((EmailId == reader["CustEmailAddr"].ToString()) && (GetPwd == reader["CustPwd"].ToString()))
                                {
                                    MyId = Convert.ToInt32(reader["CustId"].ToString());
                                }

                            }
                            break;

                        case SelectionChoice.Admin:

                            while (reader.Read())
                            {
                                if ((EmailId == reader["AdminEmailAddr"].ToString()) && (GetPwd == reader["AdminPwd"].ToString()))
                                {
                                    MyId = Convert.ToInt32(reader["AdminId"].ToString()); ;
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
                errorLbl.Text = error.ToString();
            }

            return MyId;
        }
    }

    public ushort SizeQuantity { get; set; }

    public Shopping()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}