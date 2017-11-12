using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddBookPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["NowManagerId"] == null)
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string numBook = txtNumBook.Text;
        string numSpecial = txtNumSpecial.Text;
        string address = txtAddress.Text;
        string author = txtAuthor.Text;
        string kind = null;
         if (drop.SelectedIndex >= 0)
        {
            kind = drop.SelectedValue.ToString();
        }
        string price = txtPrice.Text;
        string subject = txtSubject.Text;
        string printInfo = txtPrintInfo.Text;
        SQLOperation sql = new SQLOperation();
        string values = "'" + name + "','" + numSpecial + "','" + numBook + "','" + author + "','" + address + "', " + price + " ,'" + kind + "','" + printInfo + "','" + subject + "',-1";

        sql.add(" Books ", values);
        Response.Write("<script> alert('添加图书成功！');location=  'ManageBooksPage.aspx'</script> ");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManageBooksPage.aspx");
    }
}