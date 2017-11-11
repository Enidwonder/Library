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
        if(Session["NowManagerId"] != null)
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
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void repeaterlend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string id = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            DataTable dt = sql.select(" bookid ", " lendinfo ", " id=" + id);
            string bookid = dt.Rows[0][0].ToString().Trim();
            sql.delete(" lendinfo ", " id = '" + id + "'");

            sql.update(" books ", " lendinfoid = -1 ", "id = " + bookid);
            Response.Write("<script>alert('删除成功！');location='ManageLendInfoPage.aspx'</script>");

        }
        else if (e.CommandName == "agree")
        {
            string id = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            string lend = DateTime.Now.ToShortDateString().ToString();
            string retTime = DateTime.Now.AddMonths(1).ToShortDateString().ToString();
            sql.update(" lendinfo ", " status = '借出', lendtime = '" + lend + "',returntime='" + retTime + "',ContinueTimesNow=1 "," id="+id);
            Response.Write("<script>alert('处理成功！');location='ManageLendInfoPage.aspx'</script>");

        }
    }
}