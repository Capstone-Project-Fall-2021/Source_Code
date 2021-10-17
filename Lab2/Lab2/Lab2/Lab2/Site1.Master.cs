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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] == null) { 
            
            }
            else
            {
                String sqlQuery = "SELECT * FROM [USERS] WHERE [UserID] = " + Session["CurrentUser"].ToString();
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataReader queryResults = sqlCommand.ExecuteReader();

                if (queryResults.Read())
                {
                    Label3.Text = "User: "+queryResults["Username"].ToString();
                }
                sqlConnection.Close();
                queryResults.Close();
            }
            
        }
    }
}