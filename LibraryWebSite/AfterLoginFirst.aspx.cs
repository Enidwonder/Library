using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AfterLoginFirst : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["NowUserId"] != null)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (drop.SelectedIndex >= 0)
                    {
                        Session["NowSearchIndex"] = drop.SelectedValue.ToString();
                    }
                    SQLOperation sqlOperate = new SQLOperation();
                    DataTable dt = new DataTable();
                    if (Session["NowUserId"] != null)
                    {
                        string id = Session["NowUserId"].ToString();
                        dt = sqlOperate.select(" * ", " People ", " id=" + id + " and kind='user'");
                    }
                    else if (Session["NowManagerId"] != null)
                    {
                        string id = Session["NowManagerId"].ToString();
                        dt = sqlOperate.select(" * ", " People ", " id=" + id + " and kind='manager'");
                    }
                    nameLABEL.Text = dt.Rows[0][2].ToString().Trim();
                    sexLABEL.Text = dt.Rows[0][3].ToString().Trim();
                    emailLABEL.Text = dt.Rows[0][4].ToString().Trim();
                    beginTimeLABEL.Text = dt.Rows[0][9].ToString().Trim();
                    endTimeLABEL.Text = dt.Rows[0][10].ToString().Trim();
                    // nameLABEL;sexLABEL;email;beginTimeLABEL;end
                    //显示当前用户信息（select）
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('请先登录！');location='MyLibraryFirstPage.aspx'</script> ");
                }


            }
            else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        
        }

    }

    protected void changePwdBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChangePwdPage.aspx");
    }

    protected void changeUserInfoBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChangeInfoPage.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if(txtSearch.Text != null)
        {
            Session["NowSearchBook"] = txtSearch.Text;
            if (drop.SelectedIndex >= 0)
            {
                Session["NowSearchIndex"] = drop.SelectedValue.ToString();
            }
            Response.Redirect("~/BookInfoPage.aspx");
        }
        else
        {
            Response.Write("<script> alert('请输入搜索内容！');</script> ");
        }

    }
}