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
        if(Session["NowManagerId"] != null) //防止未登录处理信息
        {
            if (!IsPostBack)
            {
                SQLOperation sql = new SQLOperation();
                DataTable dt = new DataTable();
                dt = sql.select(" * ", " LendInfo ", null); //显示所有借阅信息
                repeaterlend.DataSource = dt;
                repeaterlend.DataBind();
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        
    }

    protected void btnBack_Click(object sender, EventArgs e) //返回上一页
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void repeaterlend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del") //删除借阅信息
        {
            string id = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            DataTable dt = sql.select(" bookid ", " lendinfo ", " id=" + id);
            string bookid = dt.Rows[0][0].ToString().Trim();
            sql.delete(" lendinfo ", " id = '" + id + "'");

            sql.update(" books ", " lendinfoid = -1 ", "id = " + bookid);
            Response.Write("<script>alert('删除成功！');location='ManageLendInfoPage.aspx'</script>");

        }
        else if (e.CommandName == "agree") //同意当前借阅申请
        {
            string id = e.CommandArgument.ToString();
            SQLOperation sql = new SQLOperation();
            string lend = DateTime.Now.ToShortDateString().ToString();
            string retTime = DateTime.Now.AddMonths(1).ToShortDateString().ToString();
            sql.update(" lendinfo ", " status = '借出', lendtime = '" + lend + "',returntime='" + retTime + "',ContinueTimesNow=1 "," id="+id);
           /* foreach (RepeaterItem item in repeaterlend.Items)
            {
                LinkButton btn = item.FindControl("btn") as LinkButton;
                btn.Visible
            }*/
            Response.Write("<script>alert('处理成功！');location='ManageLendInfoPage.aspx'</script>");

        }
    }
}