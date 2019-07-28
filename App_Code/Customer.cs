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
[Serializable]
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
            return CustFirstName + " " + CustLastName;
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

    public bool SignUp()
    {
        
        return SaveDataInDb();
    }

    //NOTE: SaveDataInDb() method will save all the member'fields in DB
    //and also will check an Email Id is already exist or not
    //Will return true if not exist and false if exist

    private bool SaveDataInDb()
    {

        HttpCookie cookie;

        bool signupStatus = true;

        string selectSqlQuery = "SELECT * FROM customer ";
        selectSqlQuery += " WHERE CustEmailAddr = @CustEmailAddr";

        string insertSqlQuery = "INSERT INTO customer (";
        insertSqlQuery += "CustId, CustFirstName, CustLastName, CustPwd, CustMobNo, CustEmailAddr, CustImg ) ";
        insertSqlQuery += "VALUES (";
        insertSqlQuery += "@CustId, @CustFirstName, @CustLastName, @CustPwd, @CustMobNo, @CustEmailAddr, @CustImg )";

        MySqlConnection connection = new MySqlConnection(connectionString);

        MySqlCommand cmd = new MySqlCommand(selectSqlQuery, connection);

        MySqlCommand cmdInsert = new MySqlCommand(insertSqlQuery, connection);

       // MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlDataReader readerSignup;

        //Add parameters for Selct 
        cmd.Parameters.AddWithValue("@CustEmailAddr", EmailId);

        // Add the parameters for insert
        cmdInsert.Parameters.AddWithValue("@CustId", MyId);

        cmdInsert.Parameters.AddWithValue("@CustEmailAddr", EmailId);

        cmdInsert.Parameters.AddWithValue("@CustFirstName", CustFirstName);

        cmdInsert.Parameters.AddWithValue("@CustLastName", CustLastName);

        cmdInsert.Parameters.AddWithValue("@CustPwd", GetPwd);

        cmdInsert.Parameters.AddWithValue("@CustMobNo", CustMobNo);

        cmdInsert.Parameters.AddWithValue("@CustImg", CustImg);

        //  cmdInsert.Parameters.AddWithValue("@CustEmailAddr", EmailId);

        //Will use Try & catch block to be suscessful connection
        int added = 0;

        try
        {
            //To dispose the connection Obj successfully

            using (connection)
            {
                //Open Databse connection 
                connection.Open();

                readerSignup = cmd.ExecuteReader();

                //Will check an Email id is already exist or not 

                while (readerSignup.Read())
                {
                    //If exist  

                    if ( EmailId == readerSignup["CustEmailAddr"].ToString() )
                    {
                        signupStatus = false;
                        //validatorEmail.Text = "Email Id is already exist";
                        //validatorEmail.Text += "Click on forgot password";
         
                    }

                }

                //Insert record if no existing user in Database
                if (signupStatus)
                {
                    readerSignup.Close();
                    added = cmdInsert.ExecuteNonQuery();
                }
                
            }
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine("Sign up Error" + error);
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
          //  System.Web.HttpContext.Current.Response.Redirect("Home.aspx");

            //Mail info to client
            SendSignUpMail();

            signupStatus = true;
        }

       return signupStatus;
    }

    /* Note: SendSignUpMail() function uses seperate CustomerMail Class
     * to send the Customer info to the Class  member properties 
     * which then Only sets the values form customer Obj 
     */

    private void SendSignUpMail()
    {
        //Initialize this Obj for Email 
        CustomerMail custMail = new CustomerMail();
        
        //will take .html Email Template 
        custMail.EmailSenderFileName = "WelcomeEmailer.html";

        //will set the Email subject
        custMail.EmailSubject = "Welcome To Burnt Umber";

        //will replace the [CustFullName] word from Template 

        //Use Srtring Bulder class to Replace multiple things 
        StringBuilder emailContentReplaceText = new StringBuilder(custMail.EmailContentText);

        emailContentReplaceText.Replace("[CustFullName]", CustFullName);

        emailContentReplaceText.Replace("[CustEmail]", EmailId);

        //Set the replaced one text 
        custMail.EmailContentText = emailContentReplaceText.ToString();

        //Set to which customer Email id 
        custMail.EmailRecieverId = EmailId;
        //Send mail to the recipant
        custMail.SendingMail();
       
    }

    public bool CheckCookie()
    {
        HttpCookie cookie;

        bool isCookiePresent = false;

        cookie = System.Web.HttpContext.Current.Request.Cookies["CustomerInfo"];

        if (cookie != null)
        {
            MyId = Convert.ToInt32(cookie["CustId"]);

            isCookiePresent = true;
        }
        return isCookiePresent;
    }

    /* Note: If customer Signs up successfully 
     * Retrive all customer data with associated customer Id  
      i.e Troughout their name to what they ardered 
     */
    public void DisplayCustomerData()
    {
        string selectSqlQueryCust = "SELECT CustFirstName, CustLastName, CustMobNo,  CustEmailAddr, CustImg, CustShipAddr, CustShipCountry, CustShipState, CustShipCity, CustShipPinCode FROM customer ";

        selectSqlQueryCust += "INNER JOIN customer_address ";

        selectSqlQueryCust += " ON customer.CustId = customer_address.CustId ";

        selectSqlQueryCust += " WHERE customer.CustId = @CustId";

        MySqlConnection connection = new MySqlConnection(connectionString);

        MySqlCommand cmd;

        MySqlDataReader reader;

        cmd = new MySqlCommand(selectSqlQueryCust, connection);

        //Add the paramaters 
        cmd.Parameters.AddWithValue("@CustId", MyId);


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
                   
                    CustFirstName = reader["CustFirstName"].ToString();

                    CustLastName = reader["CustLastName"].ToString();

                    CustMobNo = Convert.ToInt32(reader["CustMobNo"]);

                    EmailId = reader["CustEmailAddr"].ToString();

                    CustImg = reader["CustImg"].ToString();

                    CustShippAddr = reader["CustShipAddr"].ToString();

                    CustShipCountry = reader["CustShipCountry"].ToString();

                    CustShipState = reader["CustShipState"].ToString();

                    CustShipCity = reader["CustShipCity"].ToString();

                    CustShipPinCode = Convert.ToInt32(reader["CustShipPinCode"]);

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