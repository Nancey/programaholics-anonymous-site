/* Course Project Week 8
 * ProjMaster.master.cs
 * Web 460
 * By Felix Rodriguez
 * Professor Henry
 * DeVry University
 */

// Required
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Overall
public partial class ProjMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Method to save and return feedback from user
    public Label UserFeedBack
    {
        get { return lblUserFeedBack; }
        set { lblUserFeedBack = value; }
    }
}
