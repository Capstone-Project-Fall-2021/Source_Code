/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is a Search Friend page which is for searchig , adding, removing a friend

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
    public partial class SearchFriend : System.Web.UI.Page
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



            if (!IsPostBack)
            {

                //Creating sql query-select username and password from DB
                String sqlQuery = "SELECT * FROM FRIENDS WHERE user1 = " + Session["CurrentUser"].ToString();
                //Defining Connection String to DB
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                //Adding parameters for SQL injections
                sqlConnection.Open();
                SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
                while (sqlQueryResults.Read())
                {
                    FriendList.Items.Add(sqlQueryResults["friendUname"].ToString());
                }
                sqlConnection.Close();
                sqlQueryResults.Close();
            }
          
            
        }
        protected void Search_Click(object sender, EventArgs e) {
            //Creating sql query-select username and password from DB
            String sqlQuery = "SELECT * FROM [USERS] WHERE EmailAddress = @EmailAddress" ;
            //Defining Connection String to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Adding parameters for SQL injections31e
            sqlCommand.Parameters.AddWithValue("@EmailAddress", HttpUtility.HtmlEncode(SearchBox.Text.ToString()));
            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();

            if (sqlQueryResults.Read())
            {
           
         
                    friend.Items.Clear();
                    friend.Items.Add(sqlQueryResults["Username"].ToString());
                    SearchBox.Text = "";
                    Label1.Text = "";
            
                
              
            }
            else {
                friend.Items.Clear();
                SearchBox.Text = "";
                Label1.Text = "User not found try again";
          
            }

            sqlConnection.Close();
            sqlQueryResults.Close();


        }
        protected void Add_Click(object seder, EventArgs e) {
            Session["OptionSelected"] = friend.SelectedItem.ToString();
            String optionselected = Session["OptionSelected"].ToString();
            //Creating sql query-select username and password from DB
            String sqlQuery = "SELECT * FROM USERS WHERE Username = " + "'"+ optionselected+"'";
            //Defining Connection String to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Adding parameters for SQL injections
            
            sqlConnection.Open();
            
            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
            if (sqlQueryResults.Read()) {
                Session["SearchedUser"] = sqlQueryResults["UserID"].ToString();
                Session["SearchedUserName"] = sqlQueryResults["Username"].ToString();
            }
            sqlConnection.Close();
            sqlQueryResults.Close();

            
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //Creating sql transaction to be executed
                cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO FRIENDS VALUES("+ Session["CurrentUser"].ToString() + ", " + Session["SearchedUser"].ToString() + ", " +"'"+Session["SearchedUserName"].ToString()+"'"+ ") COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
                cmd.Connection = sqlConnect;
                //Opens connection
                sqlConnect.Open();
                //Executes query
                cmd.ExecuteNonQuery();
                sqlConnect.Close();
            Response.Redirect("SearchFriend.aspx");
        }
        protected void Remove_Click(object sender, EventArgs e) {
            Session["Selected"] = FriendList.SelectedItem.ToString();
            String optionselected = Session["Selected"].ToString();
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Creating sql transaction to be executed
            cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY DELETE FROM FRIENDS WHERE friendUname = "+"'"+Session["Selected"].ToString()+"'"+" AND user1 = "+ "'"+Session["CurrentUser"].ToString()+"'" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.Connection = sqlConnect;
            //Opens connection
            sqlConnect.Open();
            //Executes query
            cmd.ExecuteNonQuery();
            sqlConnect.Close();
            Response.Redirect("SearchFriend.aspx");

        }
        protected void Home_Click(object sender, EventArgs e) {
 
            Response.Redirect("HomePage.aspx");
        }

        protected void View_Click(object sender, EventArgs e)
        {
            Session["Selected"] = FriendList.SelectedItem.ToString();
            String optionselected = Session["Selected"].ToString();

            //Create query
            String sqlQuery = "SELECT * FROM USERS WHERE Username =" + "'" + optionselected + "'";
            //Defining connection to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Open connection
            sqlConnection.Open();

            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();
            if (sqlQueryResults.Read())
            {
                

                    Session["SelectedUserID"] = sqlQueryResults["UserID"].ToString();
                    Response.Redirect("AnalysisCommons.aspx");
                
            }
            sqlConnection.Close();
            sqlQueryResults.Close();

        }
    }
}