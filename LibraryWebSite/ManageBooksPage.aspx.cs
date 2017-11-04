using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageBooksPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SQLOperation sql = new SQLOperation();
            System.Data.DataTable dt = new DataTable();
            dt = sql.select(" * ", " Books ", null);
            repeaterBooks.DataSource = dt;
            repeaterBooks.DataBind();
        }
        
    }

    protected void repeaterBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void btnAddBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddBookPage.aspx");
    }
}