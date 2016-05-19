/* Course Project Week 8
 * clsBusinessLayer.cs
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
using System.Data;

/// <summary>
/// The following business layer is a complement to the data layer and presentation layer.
/// Required for maintaining datafiles.
/// Specifically, the file is tblUsers.xml.
/// Also tied to the gridview for apps completed.
/// LogIn functions have been enabled.
/// </summary>
/// 

// Overall class
public class clsBusinessLayer
{
    // Default path to the file
    string dataPath;

    // Instance of the object, clsDataLayer
    clsDataLayer myDataLayer;

    // Method to connect the file and database
    public clsBusinessLayer(string serverMappedPath)
    {
        // Always double check if the files are set in the right folders.
        dataPath = serverMappedPath;
        myDataLayer = new clsDataLayer(dataPath + "Users.accdb");
    }

    // Method to display info in the tblUsers.xml
    public DataSet GetCustomerXMLFile()
    {
        // Default data set
        DataSet xmlDataSet = new DataSet();

        // Try-catch statement to return the listings
        try
        {
            // Check for customers.xml within App_Data. Could also be at the top head of folders.
            xmlDataSet.ReadXml(dataPath + "Users.xml");
        }

            // Display errors. Had an error, because I didn't the file was missing.
        catch (System.IO.FileNotFoundException error)
        {
            // Add your comments here
            dsAccounts customerListing = myDataLayer.GetAllCustomers();
            customerListing.tblUsers.WriteXml(dataPath + "Users.xml");
            xmlDataSet.ReadXml(dataPath + "Users.xml");
        }
        // Finally returns the result, the John Smiths' and Jane Does' info.
        return xmlDataSet;
    }

    // Method to add more to the file for updates
    public DataSet WriteCustomerXMLFile(System.Web.Caching.Cache appCache)
    {
        // Default cache depends on browsers and app.         
        DataSet xmlDataSet = (DataSet)appCache["CustomerDataSet"];

        // Command to execute which will add text to the file             
        xmlDataSet.WriteXml(dataPath + "tblUsers.xml");

        // Displays again just to check for confirmation
        return xmlDataSet;
    }

    // Method to authorize the user
    public bool CheckUserCredentials(System.Web.SessionState.HttpSessionState currentSession,
                                                    string username, string password)
    {
        bool isValid = myDataLayer.ValidateUser(username, password);

        // Set the lock to false obviously so the user has at least one attempt to login.
        currentSession["LockedSession"] = false;

        /* The logic for the following lines are as follows:
         * The user has at least 3 chances to log in succesfully.
         * A count is kept at each attempt. Failure will lock the user out
         */
        int totalAttempts = Convert.ToInt32(currentSession["AttemptCount"]) + 1;
        currentSession["AttemptCount"] = totalAttempts;

        // Add one to total attempts
        int userAttempts = Convert.ToInt32(currentSession[username]) + 1;
        currentSession[username] = userAttempts;

        // Conditional statement to lock the user out after 3 or 6 attempts.
        if ((userAttempts >= 3) || (totalAttempts >= 6))
        {
            currentSession["LockedSession"] = true;
            myDataLayer.LockUserAccount(username);
        }
        return isValid;
    }
}
