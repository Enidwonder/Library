using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageUsersPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["NowManagerId"] != null)
        {
            if (!IsPostBack)
            {
                SQLOperation sql = new SQLOperation();
                DataTable dt = new DataTable();
                dt = sql.select(" * ", " People ", " kind = 'user'");
                repeaterUser.DataSource = dt;
                repeaterUser.DataBind();
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void repeaterUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string number = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            sql.delete(" People ", " number = '" + number + "' and kind = 'user'");
            Response.Write("<script>alert('删除成功！');location='ManageUsersPage.aspx'</script>");

        }
    }
}