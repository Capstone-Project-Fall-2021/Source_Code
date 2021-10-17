/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is a Analysis Page to view analysis results, analyzed story contents and submit new analysis request

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
    public partial class AnalysisPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restrict user's access if she/he has not logged in yet
            if (Session["CurrentUser"] == null)
            {
                Session["InvalidUsage"] = "You must first Log in to view the site!";
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }

            if (!IsPostBack)
            { 
                //shows all analysis a user currently has
                String sqlQueryBox = "SELECT STORY.*, STORY_ANALYSIS.* FROM STORY LEFT OUTER JOIN STORY_ANALYSIS ON STORY.TextID = STORY_ANALYSIS.TextID WHERE STORY.UserID = " + Session["CurrentUser"].ToString() + "AND STORY_ANALYSIS.AnalysisID is not null";
                SqlConnection sqlConnectionBox = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommandBox = new SqlCommand(sqlQueryBox, sqlConnectionBox);

                sqlConnectionBox.Open();
                SqlDataReader queryBox = sqlCommandBox.ExecuteReader();

                while (queryBox.Read())
                {
                    analysisBox.Items.Add(queryBox["TextTitle"].ToString());

                }
                sqlConnectionBox.Close();
                queryBox.Close();
                //analysis.SelectCommand ="SELECT STORY.*, STORY_ANALYSIS.* FROM STORY INNER JOIN STORY_ANALYSIS ON STORY.TextID = STORY_ANALYSIS.TextID WHERE STORY.UserID = " + Session["CurrentUser"].ToString() + "AND STORY_ANALYSIS.AnalysisStatus = 'complete'";

                //shows all analysis that a user is currently sharing
                String sqlQueryBox2 = "SELECT STORY.*, STORY_ANALYSIS.* FROM STORY LEFT OUTER JOIN STORY_ANALYSIS ON STORY.TextID = STORY_ANALYSIS.TextID WHERE STORY.UserID = " + Session["CurrentUser"].ToString() + "AND STORY_ANALYSIS.AnalysisID is not null AND STORY_ANALYSIS.status = 'yes'";
                SqlConnection sqlConnectionBox2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommandBox2 = new SqlCommand(sqlQueryBox2, sqlConnectionBox2);

                sqlConnectionBox2.Open();
                SqlDataReader queryBox2 = sqlCommandBox2.ExecuteReader();

                while (queryBox2.Read())
                {
                    SharedAnalysis.Items.Add(queryBox2["TextTitle"].ToString());

                }
                sqlConnectionBox2.Close();
                queryBox2.Close();
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Select_Click(object sender, EventArgs e)
        {
               
                Session["OptionSelectedStory"] = analysisBox.SelectedItem.ToString();
            String optionSelcted = Session["OptionSelectedStory"].ToString();
            //Create query
            String sqlQuery = "SELECT STORY.*, ANALYSIS.*, STORY_ANALYSIS.* FROM ANALYSIS INNER JOIN STORY_ANALYSIS ON ANALYSIS.AnalysisID = STORY_ANALYSIS.AnalysisID INNER JOIN STORY ON STORY_ANALYSIS.TextID = STORY.TextID WHERE STORY.UserID = " + Session["CurrentUser"].ToString() + " AND STORY_ANALYSIS.AnalysisID is not null " + "AND STORY.TextTitle = " + "'" + optionSelcted + "'";
            //Defining connection to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Open connection
            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
            if (sqlQueryResults.Read())
            {
                if (optionSelcted.Equals(sqlQueryResults["TextTitle"].ToString()))
                {

                    aBody.Text = sqlQueryResults["AnalysisResults"].ToString();
                    aDate.Text = sqlQueryResults["AnalysisDate"].ToString();
                    aDescription.Text = sqlQueryResults["AnalysisDescription"].ToString();
                }
            }
            sqlConnection.Close();
            sqlQueryResults.Close();
        }
        //Back button to redirect back to HomePage
            protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        //Submit new button for submission of new analysis
        protected void SubmitNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitPage.aspx");
        }

        protected void Share_Click(object sender, EventArgs e)
        {
          
            Session["OptionSelected"] = analysisBox.SelectedItem.ToString();
            String optionSelcted = Session["OptionSelected"].ToString();
            //Create query
            String sqlQuery = "SELECT STORY.*, ANALYSIS.*, STORY_ANALYSIS.* FROM ANALYSIS INNER JOIN STORY_ANALYSIS ON ANALYSIS.AnalysisID = STORY_ANALYSIS.AnalysisID INNER JOIN STORY ON STORY_ANALYSIS.TextID = STORY.TextID WHERE STORY.UserID = " + Session["CurrentUser"].ToString() + " AND STORY_ANALYSIS.AnalysisID is not null " + "AND STORY.TextTitle = " + "'" + optionSelcted + "'";
            //Defining connection to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Open connection
            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
            if (sqlQueryResults.Read())
            {
                if (optionSelcted.Equals(sqlQueryResults["TextTitle"].ToString()))
                {

                    Session["StoryID"] = sqlQueryResults["TextID"].ToString();

                }
            }
            sqlConnection.Close();
            sqlQueryResults.Close();

            
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Creating sql transaction to be executed
            //cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY UPDATE USERS SET " + "FirstName = " + "'" + FName.Text + "'" + ", LastName = " + "'" + LName.Text + "'" + ", PhoneNumber = " + "'" + Phone.Text + "'" + ", EmailAddress = " + "'" + Email.Text + "'" + ", StreetAddress = " + "'" + Street.Text + "'" + ", City = " + "'" + City.Text + "'" + ", State = " + "'" + State.Text + "'" + ", ZipCode = " + "'" + Zip.Text + "'" + ", Description = " + "'" + Description.Text.Replace("'", @"''") + "'" + " WHERE UserID = " + Session["CurrentUser"].ToString() + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY UPDATE STORY_ANALYSIS SET status = 'yes' " + " WHERE TextID = " + "'" + Session["StoryID"].ToString() + "'" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";

            cmd.Connection = sqlConnect;
            //Opens connection
            sqlConnect.Open();
            //Executes query
            cmd.ExecuteNonQuery();
            sqlConnect.Close();
            Response.Redirect("AnalysisPage.aspx");
        }
    }
}
