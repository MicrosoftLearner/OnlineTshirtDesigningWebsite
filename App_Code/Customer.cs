using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Configuration;


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

    public string CustFullName
    {
        get
        {
            return CustFirstName + " " + CustFirstName;
        }
    }

    //HttpCookie cookie = new HttpCookie("CustomerInfo");

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

        MySqlCommand cmd = new MySqlCommand(selectSqlQuery, connection);

        MySqlCommand cmdInsert = new MySqlCommand(insertSqlQuery, connection);

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlDataReader reader;

        // Add the parameters
        cmdInsert.Parameters.AddWithValue("@CustId", MyId);

        cmd.Parameters.AddWithValue("@CustEmailAddr", EmailId);

        cmdInsert.Parameters.AddWithValue("@CustFirstName", CustFirstName);

        cmdInsert.Parameters.AddWithValue("@CustLastName", CustLastName);

        cmdInsert.Parameters.AddWithValue("@CustPwd", GetPwd);

        cmdInsert.Parameters.AddWithValue("@CustMobNo", CustMobNo);

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

                    if (EmailId == reader["CustEmailAddr"].ToString())
                    {
                        validatorEmail.Text = "Email Id is already exist";
                        validatorEmail.Text += "Click on forgot password";
                    }

                    //If not 

                    else
                    {
                        //If inserted successfully it returns 1

                        added = cmdInsert.ExecuteNonQuery();
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
            //Create cookie 
            cookie = new HttpCookie("CustomerInfo");

            // Store CustId to cookie
            cookie["CustId"] = MyId.ToString();
            cookie.Expires = DateTime.Now.AddDays(2);

            //Add it to the current web response
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

            //Navigate customer to home page 
            System.Web.HttpContext.Current.Response.Redirect("Home.aspx");

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
        CustomerMail custMail = new CustomerMail();

        //Set Email Sender's Email
        custMail.EmailSender = ConfigurationManager.AppSettings["SenderEmail"];

        //Set Email Sender's password
        custMail.EmailSenderPwd = ConfigurationManager.AppSettings["SenderPwd"];

        //Set Email Sender's Host
        custMail.EmailSenderHost = ConfigurationManager.AppSettings["SmtpServerHost"];

        //Set Email Sender's Port
        custMail.EmailSenderPort = System.Convert.ToInt32(ConfigurationManager.AppSettings["SenderPortNo"]);

        //Set Email Sender's Isssl
        custMail.EmailIsSSL = System.Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);

        //will take .html Email Template 
        custMail.EmailSenderFilePath = "WelcomeEmailer.html";

        //will replace the [CustFullName] word from Template 
        custMail.EmailContentText = custMail.EmailContentText.Replace("[CustFullName]", CustFullName);



    }


    /* Note: If customer Signs up successfully 
     * Retrive all customer data with associated customer Id  
      i.e Troughout their name to what they ardered 
     */
    public void DisplayCustomerData()
    {
        string selectSqlQueryCust = "SELECT  CustId, CustFirstName, CustLastName, CustMobNo,  CustEmailAddr, CustImg, CustShippingAddr, CustShipCountry, CustShipState, CustShipCity, CustShipPinCode, CustComment FROM customer";
        selectSqlQueryCust += "WHERE CustId = @CustId";

        MySqlConnection connection = new MySqlConnection(connectionString);

        MySqlCommand cmd;

        MySqlDataAdapter adaptor;

        MySqlDataReader reader;

        cmd = new MySqlCommand(selectSqlQueryCust, connection);

        //Add the paramaters 
        cmd.Parameters.AddWithValue("@CustId", MyId);

        adaptor = new MySqlDataAdapter(cmd);

        try
        {
            //To automatically dispose the connction Obj
            using (connection)
            {
                // Open the database connection
                connection.Open();
                reader = cmd.ExecuteReader();

                //Read the data from Customer table 
                //and Set the Customer's Object fields  
                while (reader.Read())
                {
                    MyId = Convert.ToInt32(reader["CustId"]);

                    CustFirstName = reader["CustFirstName"].ToString();

                    CustLastName = reader["CustLastName"].ToString();

                    CustMobNo = Convert.ToInt32(reader["CustMobNo"]);

                    EmailId = reader["CustEmailAddr"].ToString();

                    CustImg = reader["CustImg"].ToString();

                    CustShippAddr = reader["CustShippingAddr"].ToString();

                    CustShipCountry = reader["CustShipCountry"].ToString();

                    CustShipState = reader["CustShipState"].ToString();

                    CustShipPinCode = Convert.ToInt32(reader["CustShipPinCode"]);

                    CustComment = reader["CustComment"].ToString();
                }
            }
        }

        catch (Exception error)
        {
            Label errorLbl = new Label();
            errorLbl.Text = error.ToString();
        }
    }
}