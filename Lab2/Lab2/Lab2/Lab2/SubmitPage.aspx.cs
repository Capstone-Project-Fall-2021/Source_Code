/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is Submit page which is used to submit Analysis request
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
    public partial class SubmitPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restrict user access if he/she has not logged in yet
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
                //Creating sql query
                String sqlQueryBox = "SELECT * FROM STORY WHERE STORY.UserID = "+ Session["CurrentUser"].ToString();
                //Defining connection to DB
                SqlConnection sqlConnectionBox = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommandBox = new SqlCommand(sqlQueryBox, sqlConnectionBox);

                sqlConnectionBox.Open();
                SqlDataReader queryBox = sqlCommandBox.ExecuteReader();
                //while there is something to read, add text title
                while (queryBox.Read()) {
                    analysisBox.Items.Add(queryBox["TextTitle"].ToString());
                    
                }
                sqlConnectionBox.Close();
                queryBox.Close();
               
            }
          
  
            }
        

        //Back click to Analysis Page
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalysisPage.aspx");
        }
        protected void Select_Click(object sender, EventArgs e)
        {

            Session["OptionSelectedStory"] = analysisBox.SelectedItem.ToString();
            String optionSelected = Session["OptionSelectedStory"].ToString();

            String sqlQuery = "SELECT * FROM STORY WHERE STORY.UserID = " + Session["CurrentUser"].ToString() + "AND STORY.TextTitle = "+ "'"+optionSelected+"'";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();

            if (sqlQueryResults.Read())
            {
                Session["TextID"] = sqlQueryResults["TextID"].ToString();
                if (Session["OptionSelectedStory"].ToString().Equals(sqlQueryResults["TextTitle"].ToString()))
                {
                    submitDisplay.Text = "Submission Successful";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO ANALYSIS VALUES ('Test','9/12/21','Test') COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
                    cmd.Connection = sqlConnect;
                    //Opens conenction
                    sqlConnect.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnect.Close();

                    //Get the most current analysis
                    /*
                    String sqlQuery2 = "SELECT MAX(AnalysisID) FROM ANALYSIS";
                    SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);
                    SqlCommand sqlCommand2 = new SqlCommand(sqlQuery2, sqlConnection2);

                    sqlConnection2.Open();

                    SqlDataReader sqlQueryResults2 = sqlCommand2.ExecuteReader();
                    if (sqlQueryResults2.Read()) {

                        Session["AnalysisID"] = sqlQueryResults2["MAX(AnalysisID)"].ToString();
                    
                    }
                    sqlConnection2.Close();
                    sqlQueryResults2.Close();
                    */
                    //inserts new story analysis
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                    System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO STORY_ANALYSIS VALUES (" + Session["TextID"].ToString() +", " +"(Select Max(AnalysisID) from ANALYSIS), "+"'no') COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
                    cmd2.Connection = sqlConnect2;
                    //Opens conenction
                    sqlConnect2.Open();
                    cmd2.ExecuteNonQuery();
                    sqlConnect2.Close();
                    Response.Redirect("AnalysisPage.aspx");

                }
                else {
                    submitDisplay.Text = "Something went wrong";
                }
                sqlConnection.Close();
                sqlQueryResults.Close();
                

            }
        }

        //Home click which redirects to HomePage
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}

