/* Course Project Week 8
 * clsDataLayer.cls
 * Web 460
 * By Felix Rodriguez
 * Professor Henry
 * DeVry University
 */

// Required namespaces, don't delete!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// The following data layer is necessary for modifying users' info.
/// The users' info is in Users.accdb. It also connects to the respective dataset.
/// There is a method for each button in AccDetails. 
/// The following new methods for verifing credentials is added.
/// By the way, deletion is merely updating to null values.
/// </summary>

// Overall class
public class clsDataLayer
{

    // Instance, dbConnection, is created for one user.
    OleDbConnection dbConnection;

    // More connection details to ensure proper configuration
    public clsDataLayer(string Path)
    {
        // Should work first time.
        // If not check the string for errors via Microsoft.
        dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Users.accdb");
    }

    // Method to find the user's username (not legal name) based on user's query
    public dsAccounts FindUser(string Username)
    {
        // Query is case sensitive and Username is replaced with text from txtUsername
        string sqlStmt = "select * from tblUsers where Username like '" + Username + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Data adapter fills in the details
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblUsers);

        // Result will be displayed on AccDetails
        return myStoreDataSet;
    }

    // Method to update users' details
    public void UpdateUser(string Username, string city,
                                string state, string FavLang, string WorstLang, string LastProgram)
    {
        // Remember to close
        dbConnection.Open();

        // Cross references customer's details
        string sqlStmt = "UPDATE tblUsers SET Username = @username, " +
                                             "City = @city, " +
                                             "State = @state, " +
                                             "FavLang = @FavLang, " +
                                             "WorstLang = @WorstLang, " +
                                             "LastProgram = @LastProgram, " +
                                             "WHERE (tblUsers.ID = @id)";

        // Command goes into effect to display results
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Parameters are also looked at.
        OleDbParameter param = new OleDbParameter("@Username", Username);
        dbCommand.Parameters.Add(param);
        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@FavLang", FavLang));
        dbCommand.Parameters.Add(new OleDbParameter("@WorstLang", WorstLang));

        // The search is executed to find and update
        dbCommand.ExecuteNonQuery();

        // Prevent data leakage by closing
        dbConnection.Close();
    }

    // Method to delete customer's details by setting to null values
    public void DeleteUser(string Username, string city,
                                string state, string FavLang, string WorstLang, string LastProgram)
    {
        // Remember to close
        dbConnection.Open();

        // Cross references customer's details
        string sqlStmt = "UPDATE tblUsers SET Username = , " +
                                             "City = , " +
                                             "State = , " +
                                             "FavLang = , " +
                                             "WorstLang = , " +
                                             "LastProgram = , " +
                                             "WHERE (tblUsers.ID = )";

        // Command goes into effect to display results
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Parameters are also looked at.
        OleDbParameter param = new OleDbParameter("@Username", Username);
        dbCommand.Parameters.Add(param);
        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@FavLang", FavLang));
        dbCommand.Parameters.Add(new OleDbParameter("@WorstLang", WorstLang));

        // The search is executed to find and update
        dbCommand.ExecuteNonQuery();

        // Prevent data leakage by closing
        dbConnection.Close();
    }

    // Method to show all available customers in the database
    public dsAccounts GetAllCustomers()
    {
        // Adapter required to search
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("select * from tblUsers;", dbConnection);

        // Datasets is required to look for the tables and keys of customers
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblUsers);

        // Finally displays the customers. new customers can be added of course. 
        return myStoreDataSet;
    }

    // Method that authenticates the user. Password is not encrypted.
    public bool ValidateUser(string username, string password)
    {
        // Remember to close!
        dbConnection.Open();

        //  Query to match the user. If no user is found, the person is locked out.
        string sqlStmt = "SELECT * FROM tblAccounts WHERE UserID = @id AND Password = @password AND Locked = FALSE";

        // New connection started
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Parameters are the username and password for now. 
        dbCommand.Parameters.Add(new OleDbParameter("@id", username));
        dbCommand.Parameters.Add(new OleDbParameter("@password", password));

        // Reader to verify the credentials
        OleDbDataReader dr = dbCommand.ExecuteReader();

        // Read the data
        Boolean isValidAccount = dr.Read();

        // Prevents memory leakage
        dbConnection.Close();

        return isValidAccount;
    }

     // Method that locks the user out for security reasons. 
public void LockUserAccount(string username) {
    // Remember to close!
    dbConnection.Open();

    // Query to look for the user's ID
    string sqlStmt = "UPDATE tblAccounts SET Locked = True WHERE UserID = @id";
 
    // New connection set
    OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

    // Parameters are set and executed
     dbCommand.Parameters.Add(new OleDbParameter("@id", username));

    // Query is done
    dbCommand.ExecuteNonQuery();

    // Prevents memory leakage
    dbConnection.Close();
}

}
