using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Data.OleDb;

public partial class Account_AdminBlogs : System.Web.UI.Page
{

    private string uploadDirectory; // to save the file path where the folder has been created

    //Full path of folder UploadedBlogs with saved file name
    //This we are to store in the database to fetch the images 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // to stay upadated for gridview even after page referesh 
            UpdateHomeBanner();
        }

        Master.HeaderVisibility = false;
        Master.FooterVisibility = false;
        Master.AdminHeaderVisibility = true;

        // Create a new folder in your current directory 
        // to store the uplaoded images 
        string uploadedBlogs = "UploadedBlogsImages";
        uploadDirectory = Path.Combine(Request.PhysicalApplicationPath, uploadedBlogs);
    }

    private void UpdateHomeBanner()
    {
        // need to reterive the info from database 
        string selectSQL = "SELECT * FROM inner_blogs";
        DataTable dt = new DataTable();
        MySqlConnection connection = new MySqlConnection(Master.connectionString);
        MySqlCommand cmd = new MySqlCommand(selectSQL, connection);
        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

        try
        {
            using (connection)
            {
                // Open database connection 
                connection.Open();
                // Fill the Data to DataAdaptor
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridBlogData.DataSource = dt;
                    GridBlogData.DataBind();
                }
            }
        }
        catch (Exception error)
        {

            LblDatabaseError.Text = error.ToString();
        }
    }

    protected void GridBlogData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Using this code , the saved file will retain its original 
        // file name when it's placed on the server.
        //    string serverFileName = Path.GetFileName(AdminUpload.PostedFile.FileName);

        //Full path of the folder named UploadedBlogs with saved file name
        //This we are to store in the database to fetch the images 
        //     string fullUploadPath = Path.Combine("~/UploadedBlogsImages/", serverFileName);

        LblDatabaseError.Text = "RowDataBound event occured";
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    (e.Row.FindControl("GridBlogImg") as Image).ImageUrl = fullUploadPath;
        //}
    }

    protected void GridBlogData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited
        GridBlogData.EditIndex = e.NewEditIndex;
        UpdateHomeBanner();
    }

    protected void GridBlogData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Find the controls from GridView for the row which is going to update
        Label imgId = GridBlogData.Rows[e.RowIndex].FindControl("LblImgId") as Label;
        TextBox bannerName = GridBlogData.Rows[e.RowIndex].FindControl("TBoxImgName") as TextBox;
        TextBox bannerDesc = GridBlogData.Rows[e.RowIndex].FindControl("TBoxBannerDesc") as TextBox;

        // Define ADO.NET Obj

        string updateSQL = "UPDATE inner_blogs SET InnerBlogsName = @InnerBlogsName, InnerBlogsDesc= @InnerBlogsDesc WHERE InnerBlogsId=@InnerBlogsId";
        //updateSQL += "HomeBannerName = @HomeBannerName, HomeBannerDesc= @HomeBannerDesc,";
        //updateSQL += "WHERE HomeImgId = @HomeImgId";
        //updateSQL += "HomeBannerName ='" + bannerName.Text + "', HomeBannerDesc='" + bannerDesc.Text + "'WHERE HomeImgId=" + Convert.ToInt32 (imgId.Text);


        MySqlConnection connection = new MySqlConnection(Master.connectionString);
        MySqlCommand cmd = new MySqlCommand(updateSQL, connection);

        //Add with parameters 
        cmd.Parameters.AddWithValue("@InnerBlogsName", bannerName.Text.Trim());
        cmd.Parameters.AddWithValue("@InnerBlogsDesc", bannerDesc.Text.Trim());
        cmd.Parameters.AddWithValue("@InnerBlogsId", Convert.ToInt32(imgId.Text));

        try
        {
            //Open Database connection 
            using (connection)
            {
                connection.Open();
                cmd.ExecuteNonQuery();

                //Setting the EditIndex property to -1 to cancel the Edit mode in
                // GridView
                GridBlogData.EditIndex = -1;

                //Call UpdateBanenr to display data 
                UpdateHomeBanner();
            }
        }
        catch (Exception err)
        {

            LblDatabaseError.Text = err.ToString();
        }
    }

    protected void GridBlogData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in
        // GridView
        GridBlogData.EditIndex = -1;

        //Call UpdateBanenr to display data 
        UpdateHomeBanner();
    }

    protected void BtnAddHomeImg_Click(object sender, EventArgs e)
    {
        //Check that the file is actually being submitted  

        if (AdminUpload.PostedFile.FileName == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('No file specified', 'Error')", true);
            AdminUpload.ToolTip = "NO file specified";
        }
        else
        {
            // Check the extension of the file 
            string fileExtension = Path.GetExtension(AdminUpload.PostedFile.FileName);

            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".gif":
                    break;
                default:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Invalid File Format', 'Error')", true);
                    return; // instead of break we used return directly which wont execute the below code
            }

            // Using this code , the saved file will retain its original 
            // file name when it's placed on the server.
            string serverFileName = Path.GetFileName(AdminUpload.PostedFile.FileName);

            //Content type like MIME such as .jpeg, .png
            string contentType = AdminUpload.PostedFile.ContentType;

            //Full path of folder UploadedBlogs with saved file name
            //This we are to store in the database to fetch the images 
            string fullUploadPath = Path.Combine(uploadDirectory, serverFileName);
            string databaseFilePath = "~/UploadedBlogsImages/" + serverFileName;

            // Define Ado.net Connection Object 
            MySqlConnection connection = new MySqlConnection(Master.connectionString);

            //Will use after updating the database row 
            // to show the data into GridView
            int updated = 0;

            //To generate random numbers for HomeBaneerImgId column
            DateTime dTime = DateTime.Now;

            try
            {
                //We need to check that PostedFile objects's SaveAs method saves the file 
                //correctly or not
                AdminUpload.PostedFile.SaveAs(fullUploadPath);

                //We need disposable Object i.e(using) to Automatically close the connection 
                //Otherwise we need to put that code in the finally block 
                //to close the connection 
                using (connection)
                {
                    // Insert Query to insert the data 
                    string insertQuery = "INSERT INTO inner_blogs(";
                    insertQuery += "InnerBlogsId, InnerBlogsImg, InnerBlogsImgName, InnerBlogsName, InnerBlogsDesc)";
                    insertQuery += "VALUES(";
                    insertQuery += "@InnerBlogsId, @InnerBlogsImg , @InnerBlogsImgName, @InnerBlogsName, @InnerBlogsDesc)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        //Add the paramaters 
                        cmd.Parameters.AddWithValue("@InnerBlogsId", dTime.Millisecond);
                        cmd.Parameters.AddWithValue("@InnerBlogsImg", databaseFilePath);
                        cmd.Parameters.AddWithValue("@InnerBlogsName", TboxBannerName.Text);
                        cmd.Parameters.AddWithValue("@InnerBlogsDesc", TboxBannerDesc.Text);
                        cmd.Parameters.AddWithValue("@InnerBlogsImgName", serverFileName);

                        // try to open database connection 
                        connection.Open();
                        // try to execute the query  
                        updated = cmd.ExecuteNonQuery();

                        // try to close the database connection
                        // using() method will automatically dispose the connection Obj
                        // but still as a safer side we will use the connection.Close() method 
                        connection.Close();
                    }

                }

            }
            catch (Exception error)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error(" + error + ")'Error')", true);
                LblDatabaseError.Text = error.ToString();
            }

            //If the update was succeeded, refresh the Home Banner List 
            if (updated > 0)
            {
                UpdateHomeBanner();
            }

        }
    }
}