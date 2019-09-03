using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for CustomerExtension
/// </summary>
public partial class customer
{

    public void SendSignUpMail(Tuple<string, string> tupleCustomer)
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

        emailContentReplaceText.Replace("[CustFullName]", tupleCustomer.Item1);

        emailContentReplaceText.Replace("[CustEmail]", tupleCustomer.Item2);

        //Set the replaced one text 
        custMail.EmailContentText = emailContentReplaceText.ToString();

        //Set to which customer Email id 
        custMail.EmailRecieverId = tupleCustomer.Item2;
        //Send mail to the recipant
        custMail.SendingMail();

    }
    
    //public static customer CreateProduct()
    // {
    //     return new customer() { };
    // }
}