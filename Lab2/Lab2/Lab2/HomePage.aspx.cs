/*
Names: Tofig Gasimov, Christian Le
Date: 10/7/2021
Purpose: HomePage--to redirect user on specific clicks
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class HomePage : System.Web.UI.Page
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
             * This is a Home page
             * Depending on option selected, user will be redirected to Creat User, View Profile
             * Document ,Submit, Upload and Analysis pages 
             */
            try
            {
                Session["OptionSelected"] = ListBox1.SelectedItem.ToString();
            }
            catch (NullReferenceException t) {
                txtDisplay.Text = "please make a selection";
            }

            if (Session["OptionSelected"].ToString().Equals("Create Profile"))
            {
                Response.Redirect("CreateProfile.aspx");
            }
            else if (Session["OptionSelected"].ToString().Equals("View Documents"))
            {
                Response.Redirect("Documents.aspx");
            }
            else if (Session["OptionSelected"].ToString().Equals("Analysis(Local)"))
            {
                Response.Redirect("AnalysisPage.aspx");
            }
            else if (Session["OptionSelected"].ToString().Equals("View Profile"))
            {
                Response.Redirect("ViewProfilePage.aspx");
            }
            else if (Session["OptionSelected"].ToString().Equals("Submit Analysis Request"))
            {
                Response.Redirect("SubmitPage.aspx");
            }
            else if (Session["OptionSelected"].ToString().Equals("Create Document"))
            {
                Response.Redirect("FileUpload.aspx");
            }
            else if (Session["OptionSelected"].Equals("false"))
            {
                txtDisplay.Text = "Please make a selection";
            }
            else if (Session["OptionSelected"].Equals("Analysis Commons"))
            {
                Response.Redirect("SearchFriend.aspx");
            }
            else if (Session["OptionSelected"].Equals("Analysis(Story Analyzer)"))
            {
                Response.Redirect("RESTForm.aspx");
            }


        }

        //Logout click for loggin out
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx?loggedout=true");
        }
    }
}