/* Course Project Week 8
 * AccDetails.aspx.cs
 * Web 460
 * By Felix Rodriguez
 * Professor Henry
 * DeVry University
 */


// Required namespaces, don't delete!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Overall class
public partial class AccDetails : System.Web.UI.Page
{
    // Instance of object in order to access the essentials
    clsBusinessLayer myBusinessLayer;


    // Blank for now
    protected void Page_Load(object sender, EventArgs e)
    {
        // Default text to display
        Master.UserFeedBack.Text = "Please enter details about yourself.";

        // Necessary for displaying the info for the table "Customers in Database"
        BindCustomerGridView();
    }

    // Give and return variables to AccDetails & AccConfirmation
    public TextBox Username { get { return txtUsername; }}
    public TextBox City { get { return txtCity; } }
    public TextBox State { get { return txtState; } }
    public TextBox FavLang { get { return txtFavLang; } }
    public TextBox WorstLang { get { return txtWorstLang; } }
    public TextBox LastProgram { get { return txtLastProgram; } }

    // Button with actions to find user's name (not legal name)
    protected void btnFind_Click(object sender, EventArgs e)
    {
        // Instance of object, dsAccounts
        dsAccounts dsFind;

        // My path is via App_Data.
        string tempPath = Server.MapPath("~/App_Data/Users.accdb");
        clsDataLayer dataLayerObj = new clsDataLayer(tempPath);


        // Try-catch statement to check for user's info
        try
        {
            // Reference to the usernames
            dsFind = dataLayerObj.FindUser(Username.Text);

            // Another check to make sure data is present
            if (dsFind.tblUsers.Rows.Count > 0)
            {
                // The following variables should be there from the sample data
                txtUsername.Text = dsFind.tblUsers[0].Username;
                txtCity.Text = dsFind.tblUsers[0].City;
                txtState.Text = dsFind.tblUsers[0].State;
                txtFavLang.Text = dsFind.tblUsers[0].FavLang;
                txtWorstLang.Text = dsFind.tblUsers[0].WorstLang;
                txtLastProgram.Text = dsFind.tblUsers[0].LastProgram;

                // Default error text
                Master.UserFeedBack.Text = "Record Found";
            }

            else
            {
                // Error text as a complement to above
                Master.UserFeedBack.Text = "No records were found!";
            }

        }
        catch (Exception error)
        {
            // Hopefuly the stack can trace what went wrong. 
            string message = "Something went wrong - ";
            Master.UserFeedBack.Text = message + error.Message;
        }
    }

    // Method to update users
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Set to false to ensure completion
        bool userUpdateError = false;

        // Path is literally to App_Data
        string tempPath = Server.MapPath("~/App_Data/Users.accdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        // Try-catch statement to update users with usual variables
        try
        {
            myDataLayer.UpdateUser(txtUsername.Text, txtCity.Text,
                                    txtState.Text, txtFavLang.Text, txtWorstLang.Text, txtLastProgram.Text);
        }

            // Error details for syntax, spelling or run-time issues.
        catch (Exception error)
        {
           userUpdateError = true;
            string message = "Error updating customer, please check form data. ";
            Master.UserFeedBack.Text = message + error.Message;
        }

        // If no errors, success has been made
        if (!userUpdateError)
        {
            // Wipes the controls so another update can be made
            ClearInputs(Page.Controls);
            Master.UserFeedBack.Text = "Customer Updated Successfully.";
        }

        // Necessary for displaying the info for the table "Customers in Database"
        BindCustomerGridView();
    }

    // Method to delete customers
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Set to false to ensure completion
        bool userUpdateError = false;

        // Mine is in App_Data
        string tempPath = Server.MapPath("~/App_Data/Users.accdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        // Try-catch statement to delete users
        try
        {
            myDataLayer.DeleteUser(txtUsername.Text, txtCity.Text,
                                    txtState.Text, txtFavLang.Text, txtWorstLang.Text, txtLastProgram.Text);

        }

            // Error details for syntax, spelling or run-time issues.
        catch (Exception error)
        {
            userUpdateError = true;
            string message = "Error updating customer, please check form data. ";
            Master.UserFeedBack.Text = message + error.Message;
        }

        // If no errors, success has been made
        if (!userUpdateError)
        {
            // Wipes the controls so another update can be made
            ClearInputs(Page.Controls);
            Master.UserFeedBack.Text = "Customer Updated Successfully.";
        }

        // Necessary for displaying the info for the table "Customers in Database"
        BindCustomerGridView();
    }

    // Complement to the above method to search make the following controls blank or empty
    private void ClearInputs(ControlCollection ctrls)
    {
        // Goes through each control necessary
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();
            else if (ctrl is RadioButton)
                ((RadioButton)ctrl).Checked = false;
            else if (ctrl is RadioButtonList)
                ((RadioButtonList)ctrl).ClearSelection();
            else
                ClearInputs(ctrl.Controls);
        }
    }

    //Method to display customers in the table
    private dsAccounts BindCustomerGridView()
    {
        // Alternate paths below. Mine is in App_Data.
        // Depending on where you placed your Access database, 
        //    one of the following lines may work better:
        //    tempPath = Server.MapPath("Accounts.mdb")
        //    tempPath = Server.MapPath("~/FPDB/Accounts.mdb")
        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        // Instance of object to retrieve and return customers
        dsAccounts customerListing = myDataLayer.GetAllCustomers();

        // Proper configuration for the gridview
        gvApps.DataSource = customerListing.tblUsers;

        // Finally bind the data to ensure connectivity
        gvApps.DataBind();
        Cache.Insert("CustomerDataSet", customerListing);

        return customerListing;
    }

    // Method to bind the data for proper viewing
    public void BindXMLGridView()
    {
        // Double check to make sure BindXMLGridView() is in PageLoad()!
        gvApps.DataSource = myBusinessLayer.GetCustomerXMLFile();
        gvApps.DataBind();
    }


// Export stats
    protected void btnExport_Click(object sender, EventArgs e)
    {
        // Exports to another xml file
        ClearInputs(Page.Controls);
        Master.UserFeedBack.Text = "File created.";
        BindCustomerGridView();
    }

    protected void txtFavLang_TextChanged(object sender, EventArgs e)
    {

    }
}
