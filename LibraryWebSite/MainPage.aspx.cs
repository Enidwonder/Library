using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           /* Session["NowUserId"] = null;
            Session["NowManagerId"] = null;*/
            
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != null)
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

    protected void linkMyLibrary_Click(object sender, EventArgs e)
    {
       // try
       // {
            if (Session["NowUserId"] != null)
            {
                Response.Redirect("~/AfterLoginFirst.aspx");
            }
            else if (Session["NowManagerId"] != null)
            {
                Response.Redirect("~/ManagerFirstPage.aspx");
            }
            else
            {
                Response.Redirect("~/MyLibraryFirstPage.aspx");
            }
    //}
    ///* catch(Exception ex)
    // {
    //     Response.Redirect("~/MyLibraryFirstPage.aspx");
    // }*/
}
}