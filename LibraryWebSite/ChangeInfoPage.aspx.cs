using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeInfoPage : System.Web.UI.Page
{
    static string id = null, kind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["NowUserId"] != null || Session["NowManagerId"] != null)
        {
            if (!IsPostBack)
            {

                if (Session["NowUserId"] != null)
                {
                    id = Session["NowUserId"].ToString();
                    kind = "user";
                }
                else if (Session["NowManagerId"] != null)
                {
                    id = Session["NowManagerId"].ToString();
                    kind = "manager";
                }
                SQLOperation sqlOperate = new SQLOperation();
                DataTable dt = new DataTable();
                dt = sqlOperate.select(" Email,PhoneNum ", " People ", " id=" + id + " and kind='" + kind + "'");
                //getPwd = dt.Rows[0][0].ToString().Trim()
                emailBeforeBOX.Text = dt.Rows[0][0].ToString().Trim();
                phoneNUMBOX.Text = dt.Rows[0][1].ToString().Trim();
            }
        }
        else
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        
    }

    protected void ChangeBTN_Click(object sender, EventArgs e)
    {
        string newEmail = null,newPhone = null;
        if (newEmailBOX.Text != null) newEmail = newEmailBOX.Text;
        if (phoneNUMBOX.Text != null) newPhone = phoneNUMBOX.Text;
        SQLOperation sql = new SQLOperation();
        sql.update(" People ", " Email = '" + newEmail + "' , PhoneNum = '" + newPhone + "' ", " id = " + id + " and kind = '" + kind + "'");
        if(kind == "manager")
        {
            Response.Write("<script> alert('信息修改成功！');location='ManagerFirstPage.aspx'</script> ");
        }
        else if(kind == "user")
        {
            Response.Write("<script> alert('信息修改成功！');location='AfterLoginFirst.aspx'</script> ");
        }
        
    }

    protected void Returnn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AfterLoginFirst.aspx");
    }
}