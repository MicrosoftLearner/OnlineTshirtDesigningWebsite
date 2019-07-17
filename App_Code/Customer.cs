using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer : Shopping
{
    public string CustFirstName { get; set; }

    public string CustLastName { get; set; }

    public int CustMobNo { get; set; }

    public bool CustAggree { get; set; }

    public string CustImg { get; set; }

    public string CustShippAddr { get; set; }

    public string CustShipCountry { get; set; }

    public string CustShipState { get; set; }

    public string CustShipCity { get; set; }

    public int CustShipPinCode { get; set; }

    public string CustComment { get; set; }

    HttpCookie cookie = new HttpCookie("CustomerInfo");

    public Customer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Member Methods

    public void SignUp(RequiredFieldValidator validatorEmail, Label lblError)
    {
        SaveDataInDb(validatorEmail, lblError);
    }

    //NOTE: SaveDataInDb() method will save all the member'fields in DB
    //and also will check an Email Id is already exist or not
    //Will return true if not exist and false if exist

    private void SaveDataInDb(RequiredFieldValidator validatorEmail, Label lblError)
    {
        string selectSqlQuery = "SELECT CustEmailAddr";
        selectSqlQuery += "WHERE CustEmailAddr = @CustEmailAddr";

        string insertSqlQuery = "INSERT INTO customer (";
        insertSqlQuery += "CustId, CustFirstName, CustLastName, CustPwd, CustMobNo, CustEmailAddr) ";
        insertSqlQuery += "VALUES (";
        insertSqlQuery += "@CustId, @CustFirstName, @CustLastName, @CustPwd, @CustMobNo, @CustEmailAddr )";

        MySqlConnection connection = new MySqlConnection(connectionString);

        MySqlCommand cmd = new MySqlCommand(selectSqlQuery , connection );

        MySqlCommand cmdInsert = new MySqlCommand(insertSqlQuery, connection);

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlDataReader reader;

        // Add the parameters
        cmd.Parameters.AddWithValue("@CustEmailAddr", EmailId);


        cmdInsert.Parameters.AddWithValue("@CustId", MyId);

        cmdInsert.Parameters.AddWithValue("@CustFirstName", CustFirstName);

        cmdInsert.Parameters.AddWithValue("@CustLastName", CustLastName);

        cmdInsert.Parameters.AddWithValue("@CustPwd", GetPwd);

        cmdInsert.Parameters.AddWithValue("@CustMobNo",CustMobNo );

        cmdInsert.Parameters.AddWithValue("@CustEmailAddr", EmailId);

        //Will use Try & catch block to be suscessful connection
        int added = 0;

        try
        {
            //To dispose the connection Obj successfully

            using (connection)
            {
                //Open Databse connection 
                connection.Open();
                reader = cmd.ExecuteReader();

                //Will check an Email id is already exist or not 

                while (reader.Read())
                {
                    //If exist 

                    if ( EmailId == reader["CustEmailAddr"].ToString())
                    {
                        validatorEmail.Text = "Email Id is already exist";
                        validatorEmail.Text += "Click on forgot password";
                    }

                    //If not 

                    else
                    {
                        //If inserted successfully it returns 1
                                             
                       added =  cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (Exception error)
        {
            lblError.Text = error.ToString();
        }

        //If record is added sucessfully set cookie and mail info to client

        if (added > 0)
        {
            // Store CustId to cookie
            cookie["CustId"] = MyId.ToString();
            cookie.Expires = DateTime.Now.AddDays(2);

            //Add it to the current web response
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

            //Mail info to client
            SendSignUpMail();
        }

    }

    /* Note: SendSignUpMail() function uses seperate CustomerMail Class
     * to send the Customer info to the Class  member properties 
     * which then Only sets the values form customer Obj 
     */
      
    private void SendSignUpMail()
    {
        CustomerMail cs = new CustomerMail();
    }

    public string CustFullName
    {
       get
        {
            return CustFirstName + " " + CustFirstName;
        }
    }
}