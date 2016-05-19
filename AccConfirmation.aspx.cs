/* Course Project Week 8
 * AccConfirmation.aspx.cs
 * Web 460
 * By Felix Rodriguez
 * Professor Henry
 * DeVry University
 */

//Required namespaces, don't delete!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Overall class
public partial class AccConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Try-Catch for errors with label message
        try
        {
            // Line "<%@ PreviousPageType VirtualPath="~/AccDetails.aspx" %>"
            if (PreviousPage.IsCrossPagePostBack)
            // Return values from AccDetails.aspx.cs
            { lblName.Text = PreviousPage.Username.Text; }
            { lblAddress.Text = PreviousPage.City.Text + ", " + PreviousPage.State.Text; }
            { lblFavLang.Text = PreviousPage.FavLang.Text; }
            { lblWorstLang.Text = PreviousPage.WorstLang.Text; }
            { lblLastProgram.Text = PreviousPage.LastProgram.Text; }
        }

       // Display status
        catch (Exception error)
        { lblStatus.Text = error.Message; }
    }

   
}
