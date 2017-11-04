using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RepeaterTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SQLOperation sql = new SQLOperation();
        DataTable dt = new DataTable();
        dt = sql.select(" * ", " Books ", null);
        repeater.DataSource = dt;
        repeater.DataBind();
    }

    protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}