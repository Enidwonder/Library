using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyLend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NowUserId"] != null)
        {
            string userId = Session["NowUserId"].ToString();
            if (!IsPostBack)
            {
                SQLOperation sql = new SQLOperation();
                DataTable dt = new DataTable();
                dt = sql.select(" * ", " LendInfo ", " userid="+userId);
                repeaterlend.DataSource = dt;
                repeaterlend.DataBind();
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
    }

    protected void repeaterlend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "back")
        {
            string id = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            DataTable dt = sql.select(" bookid ", " lendinfo ", " id=" + id);
            string bookid = dt.Rows[0][0].ToString().Trim();
            sql.delete(" lendinfo ", " id = '" + id + "'");

            sql.update(" books ", " lendinfoid = -1 ", " id = " + bookid);
            Response.Write("<script>alert('还书成功！');location='MyLend.aspx'</script>");

        }
        else if (e.CommandName == "continue")
        {
            string id = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            DataTable dt = sql.select(" continueTimesNow,continueTimeLimit ", " lendinfo ", " id=" + id);
            string now = dt.Rows[0][0].ToString().Trim();
            string limit = dt.Rows[0][1].ToString().Trim();
            int nowContinue = int.Parse(now);
            int limitContinue = int.Parse(limit);
            if( nowContinue < limitContinue)
            {
                string lend = DateTime.Now.ToShortDateString().ToString();
                string retTime = DateTime.Now.AddMonths(1).ToShortDateString().ToString();
                sql.update(" lendinfo ", " lendtime = '" + lend + "',returntime='" + retTime + "',ContinueTimesNow=2 ", " id=" + id);
                Response.Write("<script>alert('续借成功！');location='MyLend.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('当前书目的续借次数已经超过最大续借次数，不得续借！');location='ManageLendInfoPage.aspx'</script>");
            }
          

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AfterLoginFirst.aspx");
    }
}