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
    public string  EmailSender { private get; set; }

    public string EmailSenderPwd { private get; set; }

    public string  EmailSenderHost { private get; set; }

    public int EmailSenderPort { private get; set; }

    public bool EmailIsSSL { private get; set; }

    StreamReader str;

    public string EmailContentText { get; set; }

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


    }

    public CustomerMail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}