/* Course Project Week 8
 * LogIn.aspx.cs
 * Web 460
 * By Felix Rodriguez
 * Professor Henry
 * DeVry University
 */
    
// Required, don't delete
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Overall class
public partial class LogIn : System.Web.UI.Page
{
    // Basic load function to direct the user for now.
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserFeedBack.Text = "Please enter username and password.";
    }

    // *Updated Method to process the login credentials for authentication and authorization
    // No longer redirects to login page after successful login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Users.accdb is in App_Data
        //  Please verify that your data directory path is correct!!!!
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        // Cross reference for authorization
        bool isValidUser = myBusinessLayer.CheckUserCredentials(Session, txtUserID.Text, txtPassword.Text);
        // If the user checks out, then they will go to check out page
        if (isValidUser)
        {
            // Redirection page
            Response.Redirect("~/AccDetails.aspx");
        }
        else if (Convert.ToBoolean(Session["LockedSession"]))
        {
            Master.UserFeedBack.Text = "Account is disabled. Contact System Administrator";

            // Hide login button :-)
            btnLogin.Visible = false;
        }
        else
        {
            // Adds an attempt as failure message is displayed
            Master.UserFeedBack.Text = "The User ID and/or Password supplied is incorrect. Please try again!";
        }
    }
    protected void btnCreateAcc_Click(object sender, EventArgs e)
    {

    }
}
