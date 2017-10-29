using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeInfoPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChangeBTN_Click(object sender, EventArgs e)
    {

    }

    protected void Returnn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AfterLoginFirst.aspx");
    }
}