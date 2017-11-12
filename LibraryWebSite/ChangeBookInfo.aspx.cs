using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeBookInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NowManagerId"] != null)
        {
            if (!IsPostBack)
            {

                if (Session["NowSearchBookId"] != null)
                {
                    string id = Session["NowSearchBookId"].ToString();
                    SQLOperation sqlOperate = new SQLOperation();
                    DataTable dt = new DataTable();
                    dt = sqlOperate.select(" bookname,Address ", " books ", " id=" + id );
                    //getPwd = dt.Rows[0][0].ToString().Trim()
                    txtBookBefore.Text = dt.Rows[0][0].ToString().Trim();
                    txtAddress.Text = dt.Rows[0][1].ToString().Trim();
                }
                else
                {
                    Response.Write("<script>alert('您还没选择图书进行信息修改！');location='ManageBooksPage.aspx'</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerFirstPage.aspx");
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        string newName = null, newAddress = null;
        if (txtNewName.Text != null) newName = txtNewName.Text;
        if (txtAddress.Text != null) newAddress = txtAddress.Text;
        SQLOperation sql = new SQLOperation();
        string id = Session["NowSearchBookId"].ToString();
        sql.update(" books ", " bookname = '" + newName + "' , address = '" + newAddress + "' ", " id = " + id);
        Response.Write("<script> alert('信息修改成功！');location='ManageBooksPage.aspx'</script> ");
    }
}