using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeInfoPage : System.Web.UI.Page
{
    static string number = null, kind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if(Session["UserNownumber"] != null)
            {
                number = Session["UserNownumber"].ToString();
                kind = "user";
            }
            else if(Session["ManagerNumber"] != null)
            {
                number = Session["ManagerNumber"].ToString();
                kind = "manager";
            }
            SQLOperation sqlOperate = new SQLOperation();
            DataTable dt = new DataTable();
            dt = sqlOperate.select(" Email,PhoneNum ", " People ", " number='" + number + "' and kind='" + kind + "'");
            //getPwd = dt.Rows[0][0].ToString().Trim()
            emailBeforeBOX.Text = dt.Rows[0][0].ToString().Trim();
            phoneNUMBOX.Text = dt.Rows[0][1].ToString().Trim();
        }
    }

    protected void ChangeBTN_Click(object sender, EventArgs e)
    {
        string newEmail = null,newPhone = null;
        if (newEmailBOX.Text != null) newEmail = newEmailBOX.Text;
        if (phoneNUMBOX.Text != null) newPhone = phoneNUMBOX.Text;
        SQLOperation sql = new SQLOperation();
        sql.update(" People ", " Email = '" + newEmail + "' , PhoneNum = '" + newPhone + "' ", " number = '" + number + "' and kind = '" + kind + "'");
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