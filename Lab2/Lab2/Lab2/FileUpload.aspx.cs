/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is File upload page for uploading new story. It populates selected file into text body
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.IO;

namespace Lab2
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restrict access to user if she/he has not logged in yet
            if (Session["CurrentUser"] == null)
            {
                Session["InvalidUsage"] = "You must first Log in to view the site!";
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }


        }

        //Click to Upload selected file
        protected void Upload_Click(object sender, EventArgs e)
        {


            if (FileUpload1.HasFile)
            {
                String fpath = Request.PhysicalApplicationPath + "textfiles\\" + FileUpload1.FileName;
                FileUpload1.SaveAs(fpath);

                if (File.Exists(fpath))
                {
                    //Read all content in one string and display the string
                    String str = File.ReadAllText(fpath);
                    TextDisplay.Text = str;
                    //Delete file
                    File.Delete(fpath);

                    //defining connection to DB
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //Creating sql transaction to be executed
                    // cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO STORY VALUES ( " + "'" + date.Text + "'" + ", " + "'" + titleDisplay.Text.Replace("'", @"''") + "'" + ", " + "'" + source.Text.Replace("'", @"''") + "'" + ", " + "'" + TextDisplay.Text.Replace("'", @"''") + "'" + ", " + Session["CurrentUser"].ToString() + ")" + "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
                    cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO STORY VALUES ( @Date, @Title, @Source, @Body, " + Session["CurrentUser"].ToString() + ", 'no')" + "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
                    cmd.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(date.Text));
                    cmd.Parameters.AddWithValue("@Title", HttpUtility.HtmlEncode(titleDisplay.Text));
                    cmd.Parameters.AddWithValue("@Source", HttpUtility.HtmlEncode(source.Text));
                    cmd.Parameters.AddWithValue("@Body", HttpUtility.HtmlEncode(TextDisplay.Text));

                    cmd.Connection = sqlConnect;
                    //Opens conenction
                    sqlConnect.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnect.Close();
                    Response.Redirect("Documents.aspx");

                }
                else
                {
                    TextDisplay.Text = "Something went wrong please try again.";
                }

            }
        }

        //Save click to save newly created story
        protected void save_Click(object sender, EventArgs e)
        {
            //defining connection to DB
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            //Creating sql transaction to be executed
            // cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO STORY VALUES ( " + "'" + date.Text + "'" + ", " + "'" + titleDisplay.Text.Replace("'", @"''") + "'" + ", " + "'" + source.Text.Replace("'", @"''") + "'" + ", " + "'" + TextDisplay.Text.Replace("'", @"''") + "'" + ", " + Session["CurrentUser"].ToString() + ")" + "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO STORY VALUES ( @Date, @Title, @Source, @Body, " + Session["CurrentUser"].ToString() + ", 'no')" + "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(date.Text));
            cmd.Parameters.AddWithValue("@Title", HttpUtility.HtmlEncode(titleDisplay.Text));
            cmd.Parameters.AddWithValue("@Source", HttpUtility.HtmlEncode(source.Text));
            cmd.Parameters.AddWithValue("@Body", HttpUtility.HtmlEncode(TextDisplay.Text));

            cmd.Connection = sqlConnect;
            //Opens conenction
            sqlConnect.Open();
            cmd.ExecuteNonQuery();
            sqlConnect.Close();
            Response.Redirect("Documents.aspx");
        }

        //Back click which redirects to Documents page
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Documents.aspx");
        }

        //Home click to redirect back to HomePage
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


    }
}