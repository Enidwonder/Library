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
                
                lblName.Text = dt.Rows[0][1].ToString().Trim();
                lblAuthor.Text = dt.Rows[0][4].ToString().Trim();
                lblNumBook.Text = dt.Rows[0][3].ToString().Trim();
                lblPrice.Text = dt.Rows[0][6].ToString().Trim();
                lblPrintInfo.Text = dt.Rows[0][8].ToString().Trim();
                dt.Columns.Add("status", Type.GetType("System.String"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int LendInfo = int.Parse(dt.Rows[i][10].ToString().Trim());
                    if (LendInfo >= 0)
                    {
                        DataTable dt2 = sql.select(" status ", " LendInfo ", " id=" + LendInfo.ToString());
                        dt.Rows[i][11] = dt2.Rows[0][0].ToString().Trim();

                     /*   LinkButton btn = (LinkButton)repeater.Items[i].FindControl("btn"); //if this book has been lent, the button doesn't show
                        btn.Visible = false;*/
                    }
                    else
                    {
                        dt.Rows[i]["status"] = "可借";

                    }
                    repeater.DataSource = dt;
                    repeater.DataBind();
                }
                /*for (int i = 0; i < repeater.Items.Count; i++)
                {
                    LinkButton btn = (LinkButton)repeater.Items[i].FindControl("btn"); //if this book has been lent, the button doesn't show
                    btn.Visible = false;
                }*/
            }
            catch(Exception ex)
            {
                    Response.Write("<script> alert('此书不存在！');location='MainPage.aspx'</script> ");
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
            if(Session["NowUserId"] != null)
            {
                SQLOperation sql = new SQLOperation();
                string userId = Session["NowUserId"].ToString();
                string status = "待处理";
                string lend = DateTime.Now.ToShortDateString().ToString();
                string retTime = DateTime.Now.AddMonths(1).ToShortDateString().ToString();

                sql.add(" lendinfo ", "" + bookId.ToString() + ", " + userId.ToString() + ",'" + status + "'," + lend + "," + retTime + ",2,0");
              /*  try
                {*/
                    DataTable dtt = sql.select(" id ", " LendInfo ", " bookid=" + bookId.ToString());
                    string lendID = dtt.Rows[0][0].ToString().Trim();

                //}
                
                sql.update(" books ", " lendinfoid ='" + lendID+"'", " id=" + bookId.ToString());
                Response.Write("<script> alert('借阅申请已经发送至管理员！');location='BookInfoPage.aspx'</script> ");
            }
            else
            {
                Response.Write("<script> alert('请先登录！');location='MyLibraryFirstPage.aspx'</script> ");
            }
            
            /*sql.delete(" Books ", " NumBook = '" + numBook + "'");
            Response.Write("<script>alert('删除成功！');location='ManageBooksPage.aspx'</script>");*/
        }

    }

    protected void back_Click(object sender, EventArgs e)
    {
        if(Session["NowUserId"] != null)
        {
            Response.Redirect("~/AfterLoginFirst.aspx");
        }
        else
        {
            Response.Redirect("~/MainPage.aspx");
        }
        
    }
}