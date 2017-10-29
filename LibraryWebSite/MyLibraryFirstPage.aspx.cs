using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyLibraryFirstPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginBTN_Click(object sender, EventArgs e)
    {
        string sqlKind;
        if (kindUserBTN.Checked) sqlKind = "user";
        else if (kindManagerBTN.Checked) sqlKind = "manager";
        else sqlKind = null;
        string number = numberLoginBOX.Text;
        string pwd = passwordLoginBOX.Text;
        //SELECT 列名称 FROM 表名称 WHERE 列 运算符 值
        string getPwd;
        SQLOperation sqlOperate = new SQLOperation();
        DataTable dt = new DataTable();
       
        if(sqlKind != null)
        {
            dt = sqlOperate.select(" password ", " People ", " number='" + number + "' and kind='" + sqlKind + "'");
            if (dt.Rows.Count == 0) Response.Write("<script> alert('账号不存在');</script> ");
            else if ((getPwd = dt.Rows[0][0].ToString().Trim()) != pwd)
            {
                Response.Write("<script> alert('密码错误！');</script> ");
                passwordLoginBOX.Text = null;
            }
            else if((getPwd = dt.Rows[0][0].ToString().Trim()) == pwd)
            {
                Session["UserNownumber"] = number;
                Response.Write("<script> alert('登陆成功！');location='AfterLoginFirst.aspx'</script> ");
            }
        }else Response.Write("<script> alert('请选择类型！');</script> ");

    }
}