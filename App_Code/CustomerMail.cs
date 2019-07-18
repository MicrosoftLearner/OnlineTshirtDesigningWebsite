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
    public string EmailSender { private get; set; }

    public string EmailSenderPwd { private get; set; }

    public string EmailSenderHost { private get; set; }

    public int EmailSenderPort { private get; set; }

    public bool EmailIsSSL { private get; set; }

    StreamReader str;

    public string EmailContentText { get; set; }

    public string EmailSubject { private get; set; }

    public string EmailRecieverId { get; set; } // At which Customer's Email id has to send 

    //EmailSenderPath will set your Email Template Path 
    //According to your Email Template i.e(.html)

    public string EmailSenderFilePath
    {
        private get
        {
            return EmailSenderFilePath;
        }

        set
        {
            //EmailTemplates is the folder where all Email Templates are present

            string emailTemplateFolder = "EmailTemplates";

            //Wil get actual path along with the Folder name

            string emailTemplateDirectory = Path.Combine(System.Web.HttpContext.Current.Request.PhysicalApplicationPath, emailTemplateFolder);

            //Need to set the Email Template name with .html extension
            //from calling class

            Path.GetFileName(emailTemplateDirectory + value);

            // Read file 
            str = new StreamReader(EmailSenderFilePath);

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
            MailMessage mailMsg = new MailMessage();

            // We are sending .html template in body
            mailMsg.IsBodyHtml = true;

            //Set from Email Id i.e(Company Email id )
            mailMsg.From = new MailAddress(EmailSender);

            //Set to Email id i.e (At customer email id)
            mailMsg.To.Add(EmailRecieverId);

            //Set Mail subject 
            mailMsg.Subject = EmailSubject;

            //Set body text of mail 
            mailMsg.Body = EmailContentText;

            //Now set up your SMTP
            SmtpClient smtp = new SmtpClient();

            //Set Host server SMTP details
            smtp.Host = EmailSenderHost;

            //Set port number of SMTP
            smtp.Port = EmailSenderPort;

            //Set SSL --> True/False 
            smtp.EnableSsl = EmailIsSSL;

            //Set sender's Email id & Password 
            NetworkCredential network = new NetworkCredential(EmailSender, EmailSenderPwd);

            smtp.Credentials = network;

            //Send Method will send your Mail Message created above 
            smtp.Send(mailMsg);
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