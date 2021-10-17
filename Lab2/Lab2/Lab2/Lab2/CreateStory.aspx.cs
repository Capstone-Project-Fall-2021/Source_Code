/*
Names: Tofig Gasimov, Christian Le
Date: 9/13/2021
Purpose: This is a Create Story page to create new story. This page can be accessed through documents page on home page
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
    public partial class CreateStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restricts user access to the page if he/she has not logged in yet
            if (Session["CurrentUser"] == null)
            {
                Session["InvalidUsage"] = "You must first Log in to view the site!";
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

            }
            //Creating our query
            string sqlquery = "Select * from Story";
            //Defining the connection to DB
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);
            //Creating SQL Command iteself (sends the query to the DB)
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlquery;
            //Opens connection, sends query
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            //Creating tracker variable and assigning 0
            int tracker = 0;
            //Counts the number of rows in the table
            while (queryResults.Read())
            {

                tracker++;
            }
            Session["storageTracker"] = tracker;
            Document[] docArray = new Document[tracker];

            //when the page first loads create empty array
            if (!IsPostBack)
            {
                if (Session["OptionSelected"] == null)
                {

                }

                Session["StoryArray"] = new Document[tracker];
                Session["StoryKeeper"] = 0;

                Test.Text = Session["storageTracker"].ToString();


            }
        }

        //Button for saving and creating instance objects into memory for Create Story page
        protected void Save_Click(object sender, EventArgs e)
        {
            String txtDate = textDate.Text.ToString();
            String txtTitle = textTitle.Text.ToString();
            String txtSource = textSource.Text.ToString();
            String textBody = txtBody.Text.ToString();
            int tracker = 0;
            tracker = (int)Session["storageTracker"];
            tracker++;
            Session["storageTracker"] = tracker;
            Test.Text = Session["storageTracker"].ToString();

            //Adds story entry to the end of array
            Document[] docArray = new Document[tracker];

            int txtID = (int)Session["storageTracker"];


            docArray[tracker - 1] = new Document(txtID, txtDate, txtTitle, txtSource, textBody, (int)Session["CurrentUser"]);
            ////Adds text info to list box to check to see if it was added
            for (int i = 0; i < tracker; i++)
            {
                if (docArray[i] != null)
                {
                    TestUsers.Items.Add(docArray[i].Title.ToString());
                    Test.Text = docArray[tracker - 1].TextId.ToString();
                }
                else
                {
                    continue;
                }
            }
            Session["StoryArray"] = docArray;
            Test.Text = Session["storageTracker"].ToString();
        }
        //Clear button to clear all textbox fields
        protected void Clear_Click(object sender, EventArgs e)
        {

            textDate.Text = "";
            textTitle.Text = "";
            textSource.Text = "";
            txtBody.Text = "";

        }
        //Back button which redirects to user back to document page
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Documents.aspx");
        }

        /*Populate button to populate test data for attributes of Story Table
        protected void Populate_Click(object sender, EventArgs e)
        {
            textDate.Text = "2021-08-15";
            textTitle.Text = "Earth is flat not round";
            textSource.Text = "Article";
            txtBody.Text = "Lorem Ipsum has been the industry standard dummy text ever since the 1500";
        }
        */

        //Commit button which writes out instance object datas to the DB
       /* protected void Commit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            Document[] docArray = (Document[])Session["StoryArray"];

            int tracker = (int)Session["storageTracker"];
            //Defining connection to DB
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab1"].ConnectionString);



            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            //Creating sql transaction to be executed
            cmd.CommandText = "BEGIN TRANSACTION BEGIN TRY INSERT INTO STORY VALUES ( " + "'" + docArray[tracker].Date + "'" + ", " + "'" + docArray[tracker].Title.Replace("'", @"''") + "'" + ", " + "'" + docArray[tracker].Source.Replace("'", @"''") + "'" + ", " + "'" + docArray[tracker].Body.Replace("'", @"''") + "'" + ", " + "'" + docArray[tracker].UserID + "'" + ")" + "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
            cmd.Connection = sqlConnect;
            //Opens conenction
            sqlConnect.Open();
            //Executes a sql transaction
            cmd.ExecuteNonQuery();
            sqlConnect.Close();


        }
       */
    }
}