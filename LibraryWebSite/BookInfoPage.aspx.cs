using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookInfoPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["NowSearchBook"] != null && Session["NowSearchIndex"] != null)
        {
            string index = Session["NowSearchIndex"].ToString();
            string content = Session["NowSearchBook"].ToString();
            SQLOperation sql = new SQLOperation();
            DataTable dt = new DataTable();
            
            try
            {
                dt = sql.select(" * ", " Books ", " " + index + "=" + "'" + content + "'");
                repeater.DataSource = dt;
                repeater.DataBind();
                lblName.Text = dt.Rows[0][2].ToString().Trim();
                lblAuthor.Text = dt.Rows[0][5].ToString().Trim();
                lblNumBook.Text = dt.Rows[0][4].ToString().Trim();
                lblPrice.Text = dt.Rows[0][7].ToString().Trim();
                lblPrintInfo.Text = dt.Rows[0][9].ToString().Trim();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int LendInfo = int.Parse(dt.Rows[i][11].ToString());
                    DataTable dt2 = sql.select(" * ", " Books ", " " + index + "=" + "'" + content + "'");
                    dt.Rows[i]["status"] = "可借";

                    LinkButton btn = (LinkButton)repeater.Items[i].FindControl("btn"); //if this book has been lent, the button doesn't show
                    btn.Visible = false;
                }
                /*for (int i = 0; i < repeater.Items.Count; i++)
                {
                    LinkButton btn = (LinkButton)repeater.Items[i].FindControl("btn"); //if this book has been lent, the button doesn't show
                    btn.Visible = false;
                }*/
            }
            catch(Exception ex)
            {
                try
                {
                    dt = sql.select(" * ", " Books ", " " + index + "=" + "'" + content + "'");
                    dt.Columns.Add("status", Type.GetType("System.String"));
                    for (int i = 0; i < dt.Rows.Count; i++) { dt.Rows[i]["status"] = "可借"; }
                    repeater.DataSource = dt;
                    repeater.DataBind();
                    lblName.Text = dt.Rows[0][2].ToString().Trim();
                    lblAuthor.Text = dt.Rows[0][5].ToString().Trim();
                    lblNumBook.Text = dt.Rows[0][4].ToString().Trim();
                    lblPrice.Text = dt.Rows[0][7].ToString().Trim();
                    lblPrintInfo.Text = dt.Rows[0][9].ToString().Trim();
                                 
                   
                }
                catch(Exception exception)
                {
                    Response.Write("<script> alert('此书不存在！');location='MainPage.aspx'</script> ");
                }
            }
           
        }
        else
        {
            Response.Write("<script> alert('您尚未搜索书籍！');location='MainPage.aspx'</script> ");
        }
        
    }

    protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lend")
        {
            int bookId = int.Parse(e.CommandArgument.ToString());
            SQLOperation sql = new SQLOperation();
            string userId = Session["NowUserId"].ToString();
            string status = "待处理";
            string lend = DateTime.Now.ToShortDateString().ToString();
            string retTime = DateTime.Now.AddMonths(1).ToShortDateString().ToString();

            sql.add(" lendinfo ", "" + bookId.ToString() + ", " + userId.ToString() + ",'" + status + "'," + lend + "," + retTime + ",2,0");
            Response.Write("<script> alert('借阅申请已经发送至管理员！');</script> ");
            /*sql.delete(" Books ", " NumBook = '" + numBook + "'");
            Response.Write("<script>alert('删除成功！');location='ManageBooksPage.aspx'</script>");*/
        }

    }
}