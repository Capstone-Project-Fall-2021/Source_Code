/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is a document web page to view text body 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Data;

namespace Lab2
{
    public partial class Documents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restrict User if she/he has not logged in yet
            if (Session["CurrentUser"] == null)
            {
                Session["InvalidUsage"] = "You must first Log in to view the site!";
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }

            //When the page first loads 
            if (!IsPostBack)
            {

                String sqlQueryBox = "SELECT * FROM STORY WHERE STORY.UserID = " + Session["CurrentUser"].ToString();
                SqlConnection sqlConnectionBox = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommandBox = new SqlCommand(sqlQueryBox, sqlConnectionBox);

                sqlConnectionBox.Open();
                SqlDataReader queryBox = sqlCommandBox.ExecuteReader();

                while (queryBox.Read())
                {
                    Story.Items.Add(queryBox["TextTitle"].ToString());

                }
                sqlConnectionBox.Close();
                queryBox.Close();
            }
        }

        //Redirects user back to Home page on back button click
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        //Redirects user to create story page on click
        protected void CreateStory_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileUpload.aspx");
        }
        

        /*
         * After user has chosen title on the listbox, 
         * text body will appear on OK click according to the title
         */
        protected void OK_Click(object sender, EventArgs e)
        {
            Session["OptionSelectedStory"] = Story.SelectedItem.ToString();
            String optionSelcted = Session["OptionSelectedStory"].ToString();
            
            String sqlQuery = "SELECT * FROM STORY WHERE [UserID] = " + Session["CurrentUser"] + "AND TextTitle = " + "'" + optionSelcted + "'";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
            if (sqlQueryResults.Read())
            {
                if (optionSelcted.Equals(sqlQueryResults["TextTitle"].ToString()))
                {

                    body.Text = sqlQueryResults["TextBody"].ToString();

                }
            }
            sqlConnection.Close();
            sqlQueryResults.Close();

        }

   
    }
}