﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePwdPage : System.Web.UI.Page
{
    static string kind,id;
    SQLOperation sqlOperate = new SQLOperation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["NowUserId"] == null && Session["NowManagerId"] == null)
        {
            Response.Write("<script>alert('请先登录！');location='MyLibraryFirstPage.aspx'</script>");
        }
        if (Session["NowUserId"] != null)
        {
            id = Session["NowUserId"].ToString().Trim();
            kind = "user";
        }
        else if (Session["NowManagerId"] != null)
        {
            id = Session["NowManagerId"].ToString().Trim();
            kind = "manager";
        }
    }

    protected void changePwdBTN_Click(object sender, EventArgs e)
    {
        //string id = Session["NowUserId"].ToString();
        string pwd = beforePwdBOX.Text;
        string getPwd;
        SQLOperation sqlOperate = new SQLOperation();
        DataTable dt = new DataTable();
        dt = sqlOperate.select(" password ", " People ", " id=" + id + " and kind='"+kind+"'");
        if ((getPwd = dt.Rows[0][0].ToString().Trim()) != pwd)
        {
            Response.Write("<script> alert('密码错误！');</script> ");
            beforePwdBOX.Text = null;
        }
        else
        {
            if(newSetPwdBOX.Text != newSurePwdBOX.Text)
            {
                Response.Write("<script> alert('新密码不一致！');</script> ");
                newSetPwdBOX.Text = null;
                newSurePwdBOX.Text = null;
            }
            else
            {
                sqlOperate.update(" People ", " password = '" + newSetPwdBOX.Text + "'"," id='" + id + "'");
                Response.Write("<script> alert('修改成功！');</script> ");
            }
        }    

        
    }

    protected void returnBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AfterLoginFirst.aspx");
    }
}