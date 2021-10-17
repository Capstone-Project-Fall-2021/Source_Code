/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is Analysis Commons page which is used for viewing shared analysis 

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

namespace Lab2
{
    public partial class AnalysisCommons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] == null)
            {
                Session["InvalidUsage"] = "You must first Log in to view the site!";
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }

            //Create query
            String sqlQuery = "SELECT * FROM USERS WHERE UserID =" + Session["SelectedUserID"].ToString();
            //Defining connection to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Open connection
            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
            if (sqlQueryResults.Read())
            {

                  lblAnalysis.Text = sqlQueryResults["Username"].ToString() + " Shared Analysis' Page" ;

            }
            sqlConnection.Close();
            sqlQueryResults.Close();

            if (!IsPostBack)
            {
                String sqlQueryBox = "SELECT STORY.*, STORY_ANALYSIS.* FROM STORY LEFT OUTER JOIN STORY_ANALYSIS ON STORY.TextID = STORY_ANALYSIS.TextID WHERE STORY_ANALYSIS.status = 'yes' AND STORY.UserID = " + Session["SelectedUserID"].ToString() + "AND STORY_ANALYSIS.AnalysisID is not null";
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
            }
        }

        protected void Friend_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchFriend.aspx");
        }

        protected void Homepage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void select_Click(object sender, EventArgs e)
        {
            Session["OptionSelectedStory"] = analysisBox.SelectedItem.ToString();
            String optionSelcted = Session["OptionSelectedStory"].ToString();
            //Create query
            String sqlQuery = "SELECT STORY.*, ANALYSIS.*, STORY_ANALYSIS.* FROM ANALYSIS INNER JOIN STORY_ANALYSIS ON ANALYSIS.AnalysisID = STORY_ANALYSIS.AnalysisID INNER JOIN STORY ON STORY_ANALYSIS.TextID = STORY.TextID WHERE STORY_ANALYSIS.status = 'yes'AND STORY.UserID = " + Session["SelectedUserID"].ToString() + " AND STORY_ANALYSIS.AnalysisID is not null " + "AND STORY.TextTitle = " + "'" + optionSelcted + "'";
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
                    aDesc.Text = sqlQueryResults["AnalysisDescription"].ToString();

                }
            }
            sqlConnection.Close();
            sqlQueryResults.Close();
        }
    }
}