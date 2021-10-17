/*
Names: Tofig Gasimov, Christian Le
Date: 9/13/2021
Purpose: This is a create profile page for creating a new user
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace Lab2
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Creating our query
            string sqlquery = "Select * from Users";
            //Defining the Connection to the DB-Lab1
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab1"].ConnectionString);
            //Creating SQL Command iteself (sends the query to the DB)
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlquery;
            //Open your connection, send the query:
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            //Creating tracker variable and assigning 0 
            int tracker = 0;
            //Counts the number of rows in the table
            while (queryResults.Read())
            {

                tracker++;
            }
            Session["tracker"] = tracker;
            User[] userArray = new User[tracker];

            //When the page first loads, create and empty array
            if (!IsPostBack)
            {
                if (Session["OptionSelected"] == null)
                {

                }
                //Creating and storing values into session
                Session["UserArray"] = new User[tracker];
                Session["ArrayKeeper"] = 0;

                Test.Text = Session["tracker"].ToString();


            }
        }

        //Back button redirects to Home Page
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        //Clear button to clear all textbox fields 
        protected void Clear_Click(object sender, EventArgs e)
        {
            OrgId1.Text = "";
            FName.Text = "";
            LName.Text = "";
            Street.Text = "";
            City.Text = "";
            State.Text = "";
            Zip.Text = "";
            Phone.Text = "";
            Email.Text = "";
            Description.Text = "";

        }

        //Populate button which populates test data into empty textboxes
        protected void Populate_Click(object sender, EventArgs e)
        {
            FName.Text = "Christian";
            LName.Text = "Le";
            Street.Text = "1047 Lois Ln";
            City.Text = "Harrisonburg";
            State.Text = "Virginia";
            Zip.Text = "22801";
            Phone.Text = "(958) 645-8797";
            Email.Text = "cis484@dukes.jmu.edu";
            Description.Text = "CIS Major Graduating Fall Semester 2021-2022";
            OrgId1.Text = "1";

        }

        //Save button which creates and stores user instance objects into memory
        protected void Save_Click(object sender, EventArgs e)
        {

            String fName = FName.Text.ToString();
            String lName = LName.Text.ToString();
            String uEmail = Email.Text.ToString();
            String uPhone = Phone.Text.ToString();
            String uStreet = Street.Text.ToString();
            String uCity = City.Text.ToString();
            String uState = State.Text.ToString();
            String uZip = Zip.Text.ToString();
            String uDescription = Description.Text.ToString(); //To replace single apostrophe with double to avoid errors in sql
            int tracker = 0;
            tracker = (int)Session["tracker"];
            tracker++;
            Session["tracker"] = tracker;
            Test.Text = Session["tracker"].ToString();

            //Adds user to the end of the array
            User[] userArray = new User[tracker];

            int uId = (int)Session["tracker"];
            String orgId = OrgId1.Text;


            userArray[tracker - 1] = new User(uId, fName, lName, uEmail, uPhone, uStreet, uCity, uState, uZip, uDescription, orgId);


            //Adds user info to list box to check to see if it was added
            for (int i = 0; i < tracker; i++)
            {
                if (userArray[i] != null)
                {
                    TestUsers.Items.Add(userArray[i].FirstName.ToString());
                    Test.Text = userArray[tracker - 1].UserID.ToString();
                }
                else
                {
                    continue;
                }
            }
            Session["UserArray"] = userArray;
            Session["CurrentUser"] = tracker;




        }

        //Commit button which writes out instance object datas to the DB
        public void Commit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            User[] userArray = (User[])Session["UserArray"];
            int tracker = (int)Session["tracker"];

            string sqlquery = "INSERT INTO USERS VALUES ( " + userArray[tracker].UserID.ToString() + " " + userArray[tracker].FirstName + " " + userArray[tracker].LastName + " " + userArray[tracker].Email + " " + userArray[tracker].Phone + " " + userArray[tracker].Street + " " + userArray[tracker].City + " " + userArray[tracker].State + " " + userArray[tracker].Zip + " " + userArray[tracker].Description + " " + userArray[tracker].OrgID.ToString() + " " + ")";
            //Defining the connection to DB
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab1"].ConnectionString);


            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            //Creating sql transaction to be executed
            cmd.CommandText = " BEGIN TRANSACTION BEGIN TRY INSERT INTO USERS VALUES ( " + "'" + userArray[tracker].FirstName + "'" + ", " + "'" + userArray[tracker].LastName + "'" + ", " + "'" + userArray[tracker].Email + "'" + ", " + "'" + userArray[tracker].Phone + "'" + ", " + "'" + userArray[tracker].Street + "'" + ", " + "'" + userArray[tracker].City + "'" + ", " + "'" + userArray[tracker].State + "'" + ", " + userArray[tracker].Zip + ", " + "'" + userArray[tracker].Description.Replace("'", @"''") + "'" + ", " + OrgId1.Text + " " + ")" + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            //cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
            //cmd.Parameters.AddWithValue("@PassWord", txtPassword.Text);
            cmd.Connection = sqlConnect;
            //Open connection
            sqlConnect.Open();
            //Executes a sql transaction
            cmd.ExecuteNonQuery();
            sqlConnect.Close();











        }
    }

}