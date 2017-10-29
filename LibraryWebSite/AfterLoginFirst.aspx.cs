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
        if (!IsPostBack)
        {
            string number = Session["UserNownumber"].ToString();
            SQLOperation sqlOperate = new SQLOperation();
            DataTable dt = new DataTable();
            dt = sqlOperate.select(" * ", " People ", " number='" + number + "' and kind='user'");
            nameLABEL.Text = dt.Rows[0][2].ToString().Trim();
            sexLABEL.Text = dt.Rows[0][3].ToString().Trim();
            emailLABEL.Text = dt.Rows[0][4].ToString().Trim();
            beginTimeLABEL.Text = dt.Rows[0][9].ToString().Trim();
            endTimeLABEL.Text = dt.Rows[0][10].ToString().Trim();
            // nameLABEL;sexLABEL;email;beginTimeLABEL;end
            //显示当前用户信息（select）
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
}