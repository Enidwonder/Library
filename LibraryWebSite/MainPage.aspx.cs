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
           /* Session["UserNownumber"] = null;
            Session["ManagerNumber"] = null;*/
            searchTypeBOX.Items.Add("题名");
            searchTypeBOX.Items.Add("责任者");
            searchTypeBOX.Items.Add("主题词");
            searchTypeBOX.Items.Add("索书号");
            searchTypeBOX.Items.Add("出版社");
            searchTypeBOX.Items.Add("题名拼音");
            searchTypeBOX.Items.Add("责任者拼音");
        }
    }

    protected void searchBTN_Click(object sender, EventArgs e)
    {

    }

    protected void linkMyLibrary_Click(object sender, EventArgs e)
    {
       // try
       // {
            if (Session["UserNownumber"] != null)
            {
                Response.Redirect("~/AfterLoginFirst.aspx");
            }
            else if (Session["ManagerNumber"] != null)
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