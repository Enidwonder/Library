using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageBooksPage : System.Web.UI.Page
{
    static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["NowManagerId"] != null)
        {
            if (!IsPostBack)
            {
                SQLOperation sql = new SQLOperation();
                dt = new DataTable();
                dt = sql.select(" * ", " Books ", null);
                PageDataBind(dt, 1);
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        
        
    }

    public void PageDataBind(DataTable dt,int pageNow)
    {
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 1;
        try
        {
            pds.DataSource = dt.DefaultView;

            lblTotal.Text = pds.PageCount.ToString();

            pds.CurrentPageIndex = pageNow - 1;//当前页数从零开始，故把接受的数减一

            repeaterBooks.DataSource = pds;
            repeaterBooks.DataBind();
        }
        catch(Exception ex) { }
        
    }

    protected void repeaterBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string id = e.CommandArgument.ToString().Trim();
            SQLOperation sql = new SQLOperation();
            sql.delete(" Books ", " id ="+id);
            Response.Write("<script>alert('删除成功！');location='ManageBooksPage.aspx'</script>");
            
        }
        else if(e.CommandName == "change")
        {
            Session["NowSearchBookId"] = e.CommandArgument.ToString().Trim();
            Response.Redirect("~/ChangeBookInfo.aspx");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void btnAddBook_Click(object sender, EventArgs e) //跳转到添加书目页
    {
        Response.Redirect("~/AddBookPage.aspx");
    }

    protected void btnUp_Click(object sender, EventArgs e) //上一页
    {
        string nowPage = lblNow.Text;
        int toPage = Convert.ToInt32(nowPage) - 1;

        if (toPage >= 1)
        {
            lblNow.Text = Convert.ToString(toPage);
            PageDataBind(dt, toPage);
        }
    }

    protected void btnDown_Click(object sender, EventArgs e) //下一页
    {
        string nowPage = lblNow.Text;
        int toPage = Convert.ToInt32(nowPage) + 1;

        if (toPage <= Convert.ToInt32(lblTotal.Text))
        {
            lblNow.Text = Convert.ToString(toPage);
            PageDataBind(dt,toPage);
        }
    }

    protected void btnFirst_Click(object sender, EventArgs e)//首页
    {
            lblNow.Text = Convert.ToString(1);
            PageDataBind(dt, 1);
        
    }

    protected void btnLast_Click(object sender, EventArgs e)//尾页
    {
        lblNow.Text = lblTotal.Text;
        PageDataBind(dt, Convert.ToInt32(lblTotal.Text));
    }

    protected void btnJump_Click(object sender, EventArgs e)//跳转页
    {
        int toPage = Convert.ToInt32(txtJump.Text);
        if (toPage <= Convert.ToInt32(lblTotal.Text) && toPage >= 1)
        {
            lblNow.Text = Convert.ToString(toPage);
            PageDataBind(dt, toPage);
        }
    }

    protected void btnBack_Click1(object sender, EventArgs e) //返回上一页面
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }
}