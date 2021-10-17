/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is a Login Page which allows user to log in and access his/her sensitive data
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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIncorrectL.ForeColor = Color.Red;

            if (Session["InvalidUsage"] !=null)
            {
                lblIncorrectL.Text = Session["InvalidUsage"].ToString();
            }
            if (Session["LoggedOut"] != null)
            {
                lblIncorrectL.Text = Session["LoggedOut"].ToString();
            }
            //Display message when logged out
            //Inbound traffic to the webserver
            if(Request.QueryString.Get("loggedout") =="true")
            {
                lblIncorrectL.ForeColor = Color.Green;
                lblIncorrectL.Text = "User Successfully Logged Out!";
            }
            if (Session["UserCreated"] != null) {
                lblIncorrectL.Text = Session["UserCreated"].ToString();
            }

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            //Creating sql transaction to be executed
            cmd2.CommandText = "JeremyEzellLab3";
            //cmd2.CommandText = "Select UserID, PasswordHash from Pass where Username = @Username";
            cmd2.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
          
            cmd2.Connection = sqlConnect2;
            //Opens connection
            sqlConnect2.Open();
            SqlDataReader results = cmd2.ExecuteReader();

            if (results.HasRows) {

                while (results.Read()) {
                    string storedHash = results["PasswordHash"].ToString();

                    if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) {
                        Session["CurrentUser"] = results["UserID"].ToString();
                        Response.Redirect("HomePage.aspx");
                    }
                }
            }

            
            sqlConnect2.Close();
            results.Close();
            
           

            /* OLD LOGIN METHOD
             * 
            //Creating sql query-select username and password from DB
            String sqlQuery = "SELECT UserID, Username, Password FROM [USERS] WHERE [Username] = @UserName AND [Password] = @PassWord";
            //Defining Connection String to DB
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //Adding parameters for SQL injections
            sqlCommand.Parameters.AddWithValue("@UserName", txtUsername.Text);
            sqlCommand.Parameters.AddWithValue("@PassWord", txtPassword.Text);

            sqlConnection.Open();
  
            SqlDataReader sqlQueryResults = sqlCommand.ExecuteReader();

            if (sqlQueryResults.Read())
            {
                //Read through user id and assign current user to entered user id
                
                    Session["CurrentUser"] = sqlQueryResults["UserID"];
                    Response.Redirect("HomePage.aspx");
                
                

            }
            else
            {
                //If there is no match with password or username, display error message
                lblIncorrectL.Text = "Incorrect Username and/or Password!" +
                    " Please try again!";
            }
            sqlConnection.Close();
            sqlQueryResults.Close();

        
            */
        }
        protected void create_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewProfile.aspx");
        }
    }
}