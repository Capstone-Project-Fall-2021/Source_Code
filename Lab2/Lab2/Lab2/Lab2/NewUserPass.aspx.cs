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
    public partial class NewUserPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {


            //creates user
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            //Creating sql transaction to be executed
            //cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO USERS VALUES( " +  "'" + FName.Text + "'" + ", " + "'" + LName.Text + "'" + ", " + "'" + Phone.Text + "'" + ", " + "'" + Email.Text + "'" + ", " + "'" + Street.Text + "'" + ", " + "'" + City.Text + "'" + ", " + "'" + State.Text + "'" + ", " + "'" + Zip.Text + "'" + ", " + "'" + Description.Text.Replace("'", @"''")+"'" + ", 4, @UserName, @PassWord)" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO USERS VALUES( @Fname, @Lname, @Email, @Phone,@Street,@City,@State,@Zip,@Description, 4, @UserName)" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.Parameters.AddWithValue("@Fname", HttpUtility.HtmlEncode(Session["FirstName"].ToString()));
            cmd.Parameters.AddWithValue("@Lname", HttpUtility.HtmlEncode(Session["LastName"].ToString()));
            cmd.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(Session["Email"].ToString()));
            cmd.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(Session["Phone"].ToString()));
            cmd.Parameters.AddWithValue("@Street", HttpUtility.HtmlEncode(Session["Address"].ToString()));
            cmd.Parameters.AddWithValue("@City", HttpUtility.HtmlEncode(Session["City"].ToString()));
            cmd.Parameters.AddWithValue("@State", HttpUtility.HtmlEncode(Session["State"].ToString()));
            cmd.Parameters.AddWithValue("@Zip", HttpUtility.HtmlEncode(Session["Zip"].ToString()));
            cmd.Parameters.AddWithValue("@Description", HttpUtility.HtmlEncode(organizationText.Text));
            cmd.Parameters.AddWithValue("@UserName", HttpUtility.HtmlEncode(userNameText.Text));

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
            cmd2.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(userNameText.Text));
            cmd2.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(passwordText.Text));
            cmd2.Connection = sqlConnect2;
            //Opens connection
            sqlConnect2.Open();
            //Executes query
            cmd2.ExecuteNonQuery();
            sqlConnect2.Close();
            Session["UserCreated"] = "Please Login";
            Response.Redirect("LoginPage.aspx");

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewProfile.aspx");
        }
    }
}