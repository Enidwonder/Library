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
        if(Session["NowSearchBook"] != null && Session["NowSearchIndex"] != null)  //防止未搜索就得到书目信息
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
                for (int i = 0; i < dt.Rows.Count; i++)  //书目的馆藏信息和借阅状态
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
            SQLOperation sql = new SQLOperation();
            DataTable dtSearch = sql.select(" id ", " lendInfo ", " bookid =" + bookId); //如果这本书已经被借，不得重复借阅
            if(dtSearch == null)
            {
                if (Session["NowUserId"] != null)
                {

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

                    sql.update(" books ", " lendinfoid ='" + lendID + "'", " id=" + bookId.ToString());
                    Response.Write("<script> alert('借阅申请已经发送至管理员！');location='BookInfoPage.aspx'</script> ");
                }
                else
                {
                    Response.Write("<script> alert('请先登录！');location='MyLibraryFirstPage.aspx'</script> ");
                }
            }
            else
            {
                Response.Write("<script> alert('该书已被借！');</script> ");
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

    protected void btnShelf_Click(object sender, EventArgs e)
    {
        SQLOperation sql = new SQLOperation();
        if(Session["NowUserId"] != null)
        {
            string id = Session["NowUserId"].ToString();
            divShelf.Visible = true; //显示我的所有书架
            DataTable dt = sql.select(" * ", " myshelf ", " userid =" + id);
            repeaterMyShelf.DataSource = dt;
            repeaterMyShelf.DataBind();
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }

    }

    protected void btnCancelAdd_Click(object sender, EventArgs e)
    {
        divShelf.Visible = false; //收起我的书架的显示
    }

    protected void btnNewShelf_Click(object sender, EventArgs e)
    {
        divNewShelf.Visible = true;
    }

    protected void repeaterMyShelf_ItemCommand(object source, RepeaterCommandEventArgs e) //显示当前用户所有书架，用户可以选择一个加入也可以创建新的书架
    {
         SQLOperation sql = new SQLOperation();
        
        string shelfId = e.CommandArgument.ToString();
        string userId = Session["NowUserId"].ToString();
        string bookId = Session["NowSearchBook"].ToString();
        DataTable resultDT = sql.select(" bookid ", " I_Like ", " bookshelfId =" + shelfId); //判断这本书是不是已经存在于这个书架
        if(resultDT == null)
        {
            sql.add(" I_Like ", " bookid = " + bookId + ",userid =" + userId + ",bookShelfId =" + shelfId);
            DataTable dt = sql.select(" bookAmount ", " myshelf ", " id =" + shelfId);
            int amountBefore = 0;
            if (dt != null)
            {
                amountBefore = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            int amountNow = amountBefore + 1;
            sql.update(" myshelf ", " bookAmount = " + amountNow.ToString(), " id= " + shelfId); //这个书架的书籍本数加一
            e.Item.FindControl("btnAdd").Visible = false;
            Response.Write("<script>alert('添加书架成功！');location='BookInfoPage.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('这本书已经存在于这个书架！');</script>");
        }
        
    }

    protected void btnNew_Click(object sender, EventArgs e) //创建新的书架
    {
        SQLOperation sql = new SQLOperation();
        if (Session["NowUserId"] != null)
        {
            string id = Session["NowUserId"].ToString();
            if(txtNewShelfName != null)
            {
                string newName = txtNewShelfName.Text;
                sql.add(" myshelf ", " " + id + ", '" + newName + "', 0");
                Response.Write("<script>alert('已填加！');location='BookInfoPage.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('请输入新的书架名！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
    }
}