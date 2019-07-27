using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

//To send mail 
using System.Net.Mail;

//To use configuration files 
using System.Configuration;

using System.IO;

/// <summary>
/// Summary description for CustomerMail
/// </summary>
public class CustomerMail
{
    //Set Email Sender's Email
    private string  emailSender = ConfigurationManager.AppSettings["SenderEmail"];

    //Set Email Sender's password
    private string emailSenderPwd = ConfigurationManager.AppSettings["SenderPwd"];

    //Set Email Sender's Host
    private string emailSenderHost = ConfigurationManager.AppSettings["SmtpServerHost"];

    //Set Email Sender's Port
    private int emailSenderPort = System.Convert.ToInt32(ConfigurationManager.AppSettings["SenderPortNo"]);

    //Set Email Sender's Isssl
    private bool emailIsSSL = System.Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);

    StreamReader str;

    public string EmailContentText { get; set; }

    public string EmailSubject { private get; set; }

    public string EmailRecieverId { get; set; } // At which Customer's Email id has to send 

    //EmailSenderPath will set your Email Template Path 
    //According to your Email Template i.e(.html)
   
    public string EmailSenderFileName
    {
        set
        {
            //EmailTemplates is the folder where all Email Templates are present

            string emailTemplateFolder = "EmailTemplates";
            string filePath;
            //Wil get actual path along with the Folder name

            string emailTemplateDirectory = Path.Combine(System.Web.HttpContext.Current.Request.PhysicalApplicationPath, emailTemplateFolder);

            //Need to set the Email Template name with .html extension
            //from calling class

            filePath = Path.Combine(emailTemplateDirectory , value);

            // Read file 
            str = new StreamReader(filePath);

            //Save entire HTML to EmailContentText prop

            EmailContentText = str.ReadToEnd();

            str.Close();
        }

    }


    // Fetching mail body Text from EmailTemplate file

    public void SendingMail()
    {
        try
        {
            //Base class for seding Mail
            using (var mailMsg = new MailMessage())
            {

            // We are sending .html template in body
            mailMsg.IsBodyHtml = true;

            //Set from Email Id i.e(Company Email id )
            mailMsg.From = new MailAddress(emailSender);

            //Set to Email id i.e (At customer email id)
            mailMsg.To.Add(EmailRecieverId);

            //Set Mail subject 
            mailMsg.Subject = EmailSubject;

            //Set body text of mail 
            mailMsg.Body = EmailContentText;

            //Now set up your SMTP
            SmtpClient smtp = new SmtpClient();

            //Set Host server SMTP details
            smtp.Host = emailSenderHost;

            //Set port number of SMTP
            smtp.Port = emailSenderPort;

            //Set SSL --> True/False 
            smtp.EnableSsl = emailIsSSL;

            //Set sender's Email id & Password 
            NetworkCredential network = new NetworkCredential(emailSender, emailSenderPwd);

            smtp.Credentials = network;

            //Send Method will send your Mail Message created above 
            smtp.Send(mailMsg);
            }
         
        }
        catch (Exception errorMail)
        {
            System.Diagnostics.Debug.WriteLine("Email sending error: ", errorMail);
        }

    }

    public CustomerMail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}