/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: This is a New Profile page to create new user 

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
    public partial class NewProfile : System.Web.UI.Page
    {  //If user has not been logged in yet, she/he won't be able to see page
        protected void Page_Load(object sender, EventArgs e)
        {
         


            if (!IsPostBack)
            {

            }

        }

        //Button to update user bio info
        /*
        protected void Save_Click(object sender, EventArgs e)
        {

            //creates user
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Creating sql transaction to be executed
            //cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO USERS VALUES( " +  "'" + FName.Text + "'" + ", " + "'" + LName.Text + "'" + ", " + "'" + Phone.Text + "'" + ", " + "'" + Email.Text + "'" + ", " + "'" + Street.Text + "'" + ", " + "'" + City.Text + "'" + ", " + "'" + State.Text + "'" + ", " + "'" + Zip.Text + "'" + ", " + "'" + Description.Text.Replace("'", @"''")+"'" + ", 4, @UserName, @PassWord)" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO USERS VALUES( @Fname, @Lname, @Email, @Phone,@Street,@City,@State,@Zip,@Description, 4, @UserName)" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.Parameters.AddWithValue("@Fname", HttpUtility.HtmlEncode(FName.Text));
            cmd.Parameters.AddWithValue("@Lname", HttpUtility.HtmlEncode(LName.Text));
            cmd.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(Email.Text));
            cmd.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(Phone.Text));
            cmd.Parameters.AddWithValue("@Street", HttpUtility.HtmlEncode(Street.Text));
            cmd.Parameters.AddWithValue("@City", HttpUtility.HtmlEncode(City.Text));
            cmd.Parameters.AddWithValue("@State", HttpUtility.HtmlEncode(State.Text));
            cmd.Parameters.AddWithValue("@Zip", HttpUtility.HtmlEncode(Zip.Text));
            cmd.Parameters.AddWithValue("@Description", HttpUtility.HtmlEncode(Description.Text));
            cmd.Parameters.AddWithValue("@UserName", HttpUtility.HtmlEncode(txtUsername.Text));
          
            cmd.Connection = sqlConnect;
            //Opens connection
            sqlConnect.Open();
            //Executes query
            cmd.ExecuteNonQuery();
            sqlConnect.Close();

            //stores password
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.Text;
            //Creating sql transaction to be executed
            //cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO USERS VALUES( " +  "'" + FName.Text + "'" + ", " + "'" + LName.Text + "'" + ", " + "'" + Phone.Text + "'" + ", " + "'" + Email.Text + "'" + ", " + "'" + Street.Text + "'" + ", " + "'" + City.Text + "'" + ", " + "'" + State.Text + "'" + ", " + "'" + Zip.Text + "'" + ", " + "'" + Description.Text.Replace("'", @"''")+"'" + ", 4, @UserName, @PassWord)" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd2.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO Pass (UserID, Username, PasswordHash) VALUES ((select max(userid) from USERS), @Username, @Password)" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd2.Parameters.AddWithValue("@Username",HttpUtility.HtmlEncode(txtUsername.Text));
            cmd2.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(txtPassword.Text));
            cmd2.Connection = sqlConnect2;
            //Opens connection
            sqlConnect2.Open();
            //Executes query
            cmd2.ExecuteNonQuery();
            sqlConnect2.Close();
            Session["UserCreated"] = "Please Login";
            Response.Redirect("LoginPage.aspx");

        }
        */
        //Back button to redirect user back to Home Page
 

        protected void clear_Click(object sender, EventArgs e)
        {
           
            FName.Text = "";
            LName.Text = "";
            Email.Text = "";
            Phone.Text = "";
            Street.Text = "";
            City.Text = "";
            State.Text = "";
            Zip.Text = "";
          
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            
            Session["FirstName"] = FName.Text;
            Session["LastName"] = LName.Text;
            Session["Email"] = Email.Text;
            Session["Phone"] = Phone.Text;
            Session["Address"] = Street.Text;
            Session["City"] = City.Text;
            Session["State"] = State.Text;
            Session["Zip"] = Zip.Text;

            Response.Redirect("NewUserPass.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["FirstName"] = FName.Text;
            Session["LastName"] = LName.Text;
            Session["Email"] = Email.Text;
            Session["Phone"] = Phone.Text;
            Session["Address"] = Street.Text;
            Session["City"] = City.Text;
            Session["State"] = State.Text;
            Session["Zip"] = Zip.Text;

            Response.Redirect("NewUserPass.aspx");
        }
    }
}