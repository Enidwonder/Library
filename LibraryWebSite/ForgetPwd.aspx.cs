using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgetPwd : System.Web.UI.Page
{
    static string checkCode;
    SpecialOperations operate = new SpecialOperations();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void getCodeBTN_Click(object sender, EventArgs e)
    {
        string getEmail;
        SQLOperation sqlOperate = new SQLOperation();
        DataTable dt = new DataTable();
        string number = cardNumberBOX.Text;
        if(number == null || number == "")
        {
            Response.Write("<script> alert('请输入账号！');</script> ");
            newPwdSetBOX.Text = null;
            newPwdSureBOX.Text = null;
        }
        else
        {
            dt = sqlOperate.select(" email ", " People ", " number='" + number + "' and kind='user'");
            if (dt.Rows.Count == 0) { Response.Write("<script> alert('账号不存在');</script> "); cardNumberBOX.Text = null; }
            else
            {
                getEmail = dt.Rows[0][0].ToString();

                checkCode = operate.generateRandomNum(6);
                string body = "你的验证码是" + checkCode; //生成六位验证码发送至邮箱

                if (operate.EmailSend(body, getEmail))
                    Response.Write("<script> alert('验证码已发送至邮箱，请及时查收！');</script> ");
                else
                    Response.Write("<script> alert('验证码发送失败！');</script> ");
            }
        }
        
        
        }

    protected void setNewPwdBTN_Click(object sender, EventArgs e)
    {
        string number = cardNumberBOX.Text;
        if(number == null || number == "")
        {
            Response.Write("<script> alert('请输入账号！');</script> ");
            newPwdSetBOX.Text = null;
            newPwdSureBOX.Text = null;
        }
        else
        {
            SQLOperation sqlOperate = new SQLOperation();
            if (codeBOX.Text != checkCode)
            {
                if(codeBOX.Text==null || codeBOX.Text == "") Response.Write("<script> alert('请输入六位验证码！');</script> ");
                else
                {
                    Response.Write("<script> alert('验证码错误！');</script> ");
                    newPwdSetBOX = null;
                    newPwdSureBOX = null;
                    cardNumberBOX = null;
                }
                
            }
            else
            {
                if (newPwdSetBOX.Text != newPwdSureBOX.Text)
                {
                    Response.Write("<script> alert('新密码不一致！');</script> ");
                    newPwdSetBOX.Text = null;
                    newPwdSureBOX.Text = null;
                }
                else
                {
                    sqlOperate.update(" People ", " password = '" + newPwdSetBOX.Text + "'", " number='" + number + "'");
                    Response.Write("<script> alert('密码已修改，请重新登录！');location='MyLibraryFirstPage.aspx'</script> ");
                    codeBOX.Text = null;
                    cardNumberBOX.Text = null;
                    newPwdSetBOX.Text = null;
                    newPwdSureBOX.Text = null;
                }
            }
        
        }
            
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AfterLoginFirst.aspx");
    }
}
