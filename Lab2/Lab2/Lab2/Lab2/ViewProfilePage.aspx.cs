/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is a View Profile page which is used to update user info. 

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
    public partial class ViewProfilePage : System.Web.UI.Page
    {
        //If user has not been logged in yet, she/he won't be able to see page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"]==null)
            {
                Session["InvalidUsage"] = "You must first Log in to view the site!";
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }


            if (!IsPostBack)
            {
                //Setting current user to currently logged in user
                String sqlQuery = "SELECT * FROM [USERS] WHERE [UserID] = " + Session["CurrentUser"].ToString();
                SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection3);
                sqlConnection3.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();

                while (queryResults.Read())
                {
                    //Read through rows
                    FName.Text = queryResults["FirstName"].ToString();
                    LName.Text = queryResults["LastName"].ToString();
                    Email.Text = queryResults["EmailAddress"].ToString();
                    Phone.Text = queryResults["PhoneNumber"].ToString();
                    Street.Text = queryResults["StreetAddress"].ToString();
                    City.Text = queryResults["City"].ToString();
                    State.Text = queryResults["State"].ToString();
                    Zip.Text = queryResults["ZipCode"].ToString();
                    Description.Text = queryResults["Description"].ToString(); 

                }
                sqlConnection3.Close();
                queryResults.Close();

            }
           
        }

        //Button to update user bio info
        protected void Save_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Creating sql transaction to be executed
            //cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY UPDATE USERS SET " + "FirstName = " + "'" + FName.Text + "'" + ", LastName = " + "'" + LName.Text + "'" + ", PhoneNumber = " + "'" + Phone.Text + "'" + ", EmailAddress = " + "'" + Email.Text + "'" + ", StreetAddress = " + "'" + Street.Text + "'" + ", City = " + "'" + City.Text + "'" + ", State = " + "'" + State.Text + "'" + ", ZipCode = " + "'" + Zip.Text + "'" + ", Description = " + "'" + Description.Text.Replace("'", @"''") + "'" + " WHERE UserID = " + Session["CurrentUser"].ToString() + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY UPDATE USERS SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber, StreetAddress = @StreetAddress, City = @City, State = @State, ZipCode = @ZipCode, Description = @Description, OrganizationID = 4" +" WHERE UserID = "+Session["CurrentUser"].ToString() + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(FName.Text));
            cmd.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(LName.Text));
            cmd.Parameters.AddWithValue("@EmailAddress", HttpUtility.HtmlEncode(Email.Text));
            cmd.Parameters.AddWithValue("@PhoneNumber", HttpUtility.HtmlEncode(Phone.Text));
            cmd.Parameters.AddWithValue("@StreetAddress", HttpUtility.HtmlEncode(Street.Text));
            cmd.Parameters.AddWithValue("@City", HttpUtility.HtmlEncode(City.Text));
            cmd.Parameters.AddWithValue("@State", HttpUtility.HtmlEncode(State.Text));
            cmd.Parameters.AddWithValue("@ZipCode", HttpUtility.HtmlEncode(Zip.Text));
            cmd.Parameters.AddWithValue("@Description", HttpUtility.HtmlEncode(Description.Text));
            cmd.Connection = sqlConnect;
            //Opens connection
            sqlConnect.Open();
            //Executes query
            cmd.ExecuteNonQuery();
            sqlConnect.Close();

        }
        //Back button to redirect user back to Home Page
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        
    }
}