using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageLendInfoPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SQLOperation sql = new SQLOperation();
            DataTable dt = new DataTable();
            dt = sql.select(" * ", " LendInfo ", null);
            repeaterlend.DataSource = dt;
            repeaterlend.DataBind();
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void repeaterlend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}