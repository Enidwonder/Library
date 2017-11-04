using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerFirstPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void changePwdBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChangePwdPage.aspx");
    }

    

    protected void changeInfoBTN_Click(object sender, EventArgs e)
    {

    }
}