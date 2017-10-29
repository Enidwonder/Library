using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    SpecialOperations operate = new SpecialOperations();
    static string checkCode;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sendEmailBTN_Click(object sender, EventArgs e)
    {
        checkCode = operate.generateRandomNum(6);
        string body = "你的验证码是" + checkCode; //生成六位验证码发送至邮箱
        string toEmail;
        if (EmailBOX.Text != null && EmailBOX.Text != "" && !operate.non_string_existed(EmailBOX.Text,"@") && !operate.non_string_existed(EmailBOX.Text,".com"))
        {
            toEmail = EmailBOX.Text;
            if(operate.EmailSend(body, toEmail))
                Response.Write("<script> alert('验证码已发送至邮箱，请及时查收！');</script> ");
            else
                Response.Write("<script> alert('验证码发送失败！');</script> ");
        }
        else
        {
            Response.Write("<script> alert('邮箱格式不正确');</script> ");
            EmailBOX.Text = null;
        }
        
    }

    protected void registerBTN_Click(object sender, EventArgs e)
    {
        string beginDate = DateTime.Now.ToShortDateString().ToString();
        string endDate = DateTime.Now.AddYears(4).ToShortDateString().ToString(); //证件有效期4年
        string number = operate.generateRandomNum(10);

        string sex;
        if (sexManBTN.Checked) sex = sexManBTN.Text;
        else if (sexWomanBTN.Checked) sex = sexWomanBTN.Text;
        else sex = null;

        bool emptyJudge = operate.nullString(nameRegister.Text) || operate.nullString(sex) || operate.nullString(personIDBOX.Text) || operate.nullString(phoneNumberBOX.Text) || operate.nullString(EmailBOX.Text) || operate.nullString(codeBOX.Text) || operate.nullString(pwdSetBOX.Text) || operate.nullString(pwdSureBOX.Text);
        bool overLengthJudge = operate.overLength(nameRegister.Text, 20) || operate.overLength(personIDBOX.Text, 30) || operate.overLength(workplaceBOX.Text, 20) || operate.overLength(birthdayBOX.Text, 20) || operate.overLength(EmailBOX.Text, 20) || operate.overLength(codeBOX.Text, 6) || operate.overLength(pwdSetBOX.Text, 10);
        if (emptyJudge) Response.Write("<script> alert('有内容尚未完成！');</script> ");
        else if (overLengthJudge)
        {
            Response.Write("<script> alert('有内容超出限定长度！');</script> ");

        }
        else if (operate.not_equal(pwdSetBOX.Text, pwdSureBOX.Text)) Response.Write("<script> alert('两次输入的密码不一致');</script> ");
        else if (operate.not_equal(checkCode, codeBOX.Text)) Response.Write("<script> alert('验证码错误');</script> ");
        else
        {
            SQLOperation sql = new SQLOperation();
            //    sql = new SQLOperation();

            //' name  ','sex','email','phonenum','idcard','birthday','password'
            string values = "'" + number + "', " + "N'" + nameRegister.Text + "','" + sex + "','" + EmailBOX.Text + "','" + phoneNumberBOX.Text + "','" + personIDBOX.Text + "','" + birthdayBOX.Text + "','" + pwdSetBOX.Text + "','" + beginDate + "','" + endDate + "','" + "user'";
            sql.add("People", values);
            numberLABEL.Text = "你的账号是" + number;
            numberShow.Visible = true;
            Response.Write("<script> alert('注册成功你的账号是' + number);location='MyLibraryFirstPage.aspx'</script> ");
            /*全部清空*/
            EmailBOX.Text = null;
            codeBOX.Text = null;
            personIDBOX.Text = null;
            phoneNumberBOX.Text = null;
           // sexBOX.Text = null;
            workplaceBOX.Text = null;
            pwdSetBOX.Text = null;
            pwdSureBOX.Text = null;
            nameRegister.Text = null;
            birthdayBOX.Text = null;
        }
    }
}