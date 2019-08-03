using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccount_UserAccount : System.Web.UI.Page
{
    protected Customer cust;

    protected ManipulateCustomerData custMpData;

    private Dictionary<string, string[]> ContStateCollection
    {
        get
        {
            //Retreive from ViewState
            object d = ViewState["ContryStateCollection"];

            //set the condition
            return (d == null ? null : (Dictionary<string, string[]>)d);
        }

        set
        {
            ViewState["ContryStateCollection"] = value;
        }
    }
    // protected Dictionary<string , string[]> stateSelection;

    private int id;

    //For selecting the tabs based on Clicked links
    private string userSelectionTab;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Display user info
        cust = new Customer();
        if (!this.IsPostBack)
        {
            userSelectionTab = Request.QueryString["TabSelection"];
            
            if (cust.CheckCookie())
            {
                //Store customer in view state 

                ViewState["CustId"] = cust.MyId;

                cust.DisplayCustomerData();
    
                custMpData = cust.ShowCustManupulatedData();

                custMpData.ShowCustIdentity();

                ShowDisplayedData();

                //Check for clicked links i.e User Profile or User Address tab

                switch (userSelectionTab)
                {
                    case "Profile":
                        //To set the Multiview property 
                        LinkButtonUserProf_Click(LinkButtonUserProf, null);
                        break;

                    case "Addr":
                        LinkButtonUserAddr_Click(LinkButtonUserAddr, null);
                        break;

                    case "Order":
                        LinkButtonuserOrdered_Click(LinkButtonuserOrdered, null);
                        break;

                }

            }

            else Response.Redirect("~/UserAccount/Login.aspx");

            //This function will add the Country and state
            //In the dropdown List 
            AddCountryList();
        }

        if (this.IsPostBack)
        {
            //Retreive CustId 
            id = (int)ViewState["CustId"];
        //    cust = (Customer)ViewState["Customer"];

            //Retreive CustManupulated Obj 
            custMpData = (ManipulateCustomerData)ViewState["CustManupData"];
        }


    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        //Persist Variable

        ContStateCollection = ContStateCollection;

        //Persist  Customer Obj / Update the ViewState 
        ViewState["Customer"] = cust;

        //Persist  CustManupulated Obj / Update the ViewState 
        ViewState["CustManupData"] = custMpData;

    }

    private void AddCountryList()
    {
        //Add Country list

        if (ContStateCollection == null)
        {
            ContStateCollection = new Dictionary<string, string[]>();

            ContStateCollection.Add("India", new string[] { "Maharashtra", "Kerala", "Punjab" });

            ContStateCollection.Add("USA", new string[] { "California ", "Hawaii", "New York" });

        }

        //Set Dictionary key of country  into Dropdownlist
        foreach (string key in ContStateCollection.Keys)
        {
            DropDownListUserCountry.Items.Add(new ListItem(key));

            ListShipNewCountry.Items.Add(new ListItem(key));
        }
    }
    //For User profile Tab
    private void ShowDisplayedData()
    {

        LblUserProfEmail.Text = cust.EmailId;

        LblUserProfMob.Text = cust.CustMobNo.ToString();

        LblUserProfFullName.Text = cust.CustFullName;
    }

    protected void ButtonUserReturn_Click(object sender, EventArgs e)
    {
        //MultiViewUserOrdered.ActiveViewIndex = 1;
        

    }

    protected void ButtonUserCancelled_Click(object sender, EventArgs e)
    {

       
    }

    protected void ButtonUserOrders_Click(object sender, EventArgs e)
    {
        MultiViewUserOrdered.ActiveViewIndex = 0;
    }

    protected void LinkButtonUserProf_Click(object sender, EventArgs e)
    {
        MultiViewUserChoice.ActiveViewIndex = 0;

        MultiViewUserDtl.ActiveViewIndex = 0;

        //disable profile address tab & Orders tab 
        MultiViewUserAddr.ActiveViewIndex = -1;

        PanelUserOrder.Visible = false;
    }

    protected void LinkButtonUserAddr_Click(object sender, EventArgs e)
    {

        MultiViewUserAddr.ActiveViewIndex = 0;

        //Disable User profile 
        MultiViewUserChoice.ActiveViewIndex = -1;

        //To check customer has already a Shipping address or not 
            cust.MyId = id;

        cust.DisplayCustomerData();

        if (custMpData.ShowCustIdentity() == null)

            MultiViewUserAddr.ActiveViewIndex = 2;

        else
        {

            RptUserAddr.DataSource = custMpData.ShowCustIdentity();

            RptUserAddr.DataBind();
        }

    }

    protected void LinkButtonuserOrdered_Click(object sender, EventArgs e)
    {
        PanelUserOrder.Visible = true;

        //Disable Both tab profile & manage address tab 
        MultiViewUserChoice.ActiveViewIndex = -1;

        MultiViewUserAddr.ActiveViewIndex = -1;
    }

    //If Customer has already addresses
    protected void ButtonUserAddrSave_Click(object sender, EventArgs e)
    {
        //If all controls aren't valid 
        if (!Page.IsValid) return;

        //If all controls are valid, proceed the underneath code

        string fullAddr = String.Concat(TboxLine1.Text, " ", TboxLine2.Text).Trim();

        //Set the objects properties
        cust.CustShippAddr = fullAddr;

        cust.CustShipCountry = DropDownListUserCountry.SelectedItem.Text;

        cust.CustShipState = DropDownListUserState.SelectedItem.Text;

        cust.CustShipCity = TboxCity.Text;

        cust.CustShipPinCode = Convert.ToInt32(TboxPinCode.Text);

        cust.MyId = id;

        // save info into Database at the paricular AddressId
        //Of the customer 
        cust.SaveShipAddr(Convert.ToInt32(ButtonUserAddrSave.CommandArgument));

        //Fetch from database
        cust.DisplayCustomerData();

        //Update the ManipulateCustom obj
        custMpData = cust.ShowCustManupulatedData();

        //Store updated Customer Obj in ViewState 
       // ViewState["Customer"] = cust;

        //Sore updated Manupulated Obj in ViewState
        ViewState["CustManupData"] = custMpData;

        //Fect the Dicitionary Obj & Update the Repeater  
        RptUserAddr.DataSource = custMpData.ShowCustIdentity();

        RptUserAddr.DataBind();

        //Switch to 1st tab
        MultiViewUserAddr.ActiveViewIndex = 0;

        //Update UI 
        ShowDisplayedData();
    }

    protected void DropDownListUserCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Find the Page control through master page     

        ContentPlaceHolder mainContent = Page.Master.FindControl("MainContent") as ContentPlaceHolder;

        DropDownList dlUserState = (DropDownList)mainContent.FindControl("DropDownListUserState");

        //   // fill this state dropdown through Dictionary's Key 
        dlUserState.DataSource = ContStateCollection[DropDownListUserCountry.SelectedItem.Text];

        //   DropDownListUserState.DataTextField = "Value";

        //Activate Binding
        dlUserState.DataBind();
    }

    protected void BtnUserDtlSaved_Click(object sender, EventArgs e)
    {
        //If all controls aren't valid
        if (!Page.IsValid) return;

        //Id all controls are valid , proceed the underneath code

        //Set obj's properties 
        cust.CustFirstName = TBoxFirstName.Text.Trim();

        cust.CustLastName = TBoxLastName.Text.Trim();

        cust.CustMobNo = Convert.ToInt32(TBoxMobNo.Text.Trim());

        cust.EmailId = TBoxEmail.Text;

        cust.MyId = id;

        //Save the details
        cust.SaveCustmerInfo();

        //Fetch from database
        cust.DisplayCustomerData();

        //Store updated Customer Obj in ViewState 
     
        custMpData = cust.ShowCustManupulatedData();

        //Update UI 
        ShowDisplayedData();

    }

    protected void BtnShipNewAddrSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        //If all controls are valid, proceed the underneath code

        string fullAddr = String.Concat(TBoxNewAddrLine1.Text, TBoxNewAddrLine2.Text).Trim();

        //Set the objects properties
        cust.CustShippAddr = fullAddr;

        cust.CustShipCountry = ListShipNewCountry.SelectedItem.Text;

        cust.CustShipState = ListShipNewState.SelectedItem.Text;

        cust.CustShipCity = TBoxNewAddrCity.Text;

        cust.CustShipPinCode = Convert.ToInt32(TBoxNewAddrPinCode.Text);

         cust.MyId = id;
        // save info into Database
        cust.SaveShipNewAddr();

        //Fetch from database
        cust.DisplayCustomerData();

        //Update the ManipulateCustom obj
        custMpData = cust.ShowCustManupulatedData();

        //Sore updated Manupulated Obj in ViewState
        ViewState["CustManupData"] = custMpData;

        //Fect the Dicitionary Obj & Update the Repeater  
        RptUserAddr.DataSource = custMpData.ShowCustIdentity();

        RptUserAddr.DataBind();

        //Switch to 1st tab
        MultiViewUserAddr.ActiveViewIndex = 0;

        //Update UI 
        ShowDisplayedData();
    }

    protected void LkBtnAddMoreShipAddr_Click(object sender, EventArgs e)
    {
        MultiViewUserAddr.ActiveViewIndex = 2;
    }

    protected void ButtonUserAddrEdit_Command(object sender, CommandEventArgs e)
    {
        //Open edit tab
        MultiViewUserAddr.ActiveViewIndex = 1;

        ButtonUserAddrSave.CommandArgument = e.CommandArgument.ToString();
    
    }

    protected void RptUserAddr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblUserFirstName = e.Item.FindControl("LblUserFirstName") as Label;

        Label lblUserLasttName = e.Item.FindControl("LblUserLastName") as Label;

        Label LblUserAddrEmail = e.Item.FindControl("LblUserAddrEmail") as Label;

        Label LblUseShipAddr = e.Item.FindControl("LblUserShipAddr") as Label;

        Label LblUserShipCity = e.Item.FindControl("LblUserShipCity") as Label;

        Label LblUserShipPinCode = e.Item.FindControl("LblUserShipPinCode") as Label;

        Label LblUserShipCountry = e.Item.FindControl("LblUserShipContry") as Label;

        KeyValuePair<int, Customer> kp = (KeyValuePair<int, Customer>)e.Item.DataItem;

        //   Dictionary<int,MyClass> kp1 = kp.Value.;

        lblUserFirstName.Text = kp.Value.CustFirstName;

        lblUserLasttName.Text = kp.Value.CustLastName;

        LblUserAddrEmail.Text = kp.Value.EmailId;

        LblUseShipAddr.Text = kp.Value.CustShippAddr;

        LblUserShipCity.Text = kp.Value.CustShipCity;

        LblUserShipPinCode.Text = kp.Value.CustShipPinCode.ToString();

        LblUserShipCountry.Text = kp.Value.CustShipCountry;


    }

    protected void ListShipNewCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Find the Page control through master page     

        ContentPlaceHolder mainContent = Page.Master.FindControl("MainContent") as ContentPlaceHolder;

        DropDownList dlUserNewState = (DropDownList)mainContent.FindControl("ListShipNewState");

        dlUserNewState.DataSource = ContStateCollection[ListShipNewCountry.SelectedItem.Text];

        //Activate Binding
        dlUserNewState.DataBind();
    }

    protected void ButtonUserAddrDelete_Command(object sender, CommandEventArgs e)
    {
        cust.MyId = id;

        // save info into Database at the paricular AddressId
        //Of the customer 
        cust.DeleteShipAddr(Convert.ToInt32(e.CommandArgument));

        //Fetch from database
        cust.DisplayCustomerData();

        //Store updated Customer Obj in ViewState 
        custMpData = cust.ShowCustManupulatedData();
    }
}