﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

/// <summary>
/// SpecialOperations 的摘要说明
/// </summary>
public class SpecialOperations
{
    public bool EmailSend(string body,string toEmail)
    {
        MailMessage msg = new MailMessage();

        msg.To.Add(toEmail);//收件人地址 
       // msg.CC.Add("enid@163.com");//抄送人地址 

        msg.From = new MailAddress("enid@163.com", "Library");//发件人邮箱，名称 

        msg.Subject = "Library验证码";//邮件标题 
        msg.SubjectEncoding = Encoding.UTF8;//标题格式为UTF8 

        msg.Body = body;//邮件内容 
        msg.BodyEncoding = Encoding.UTF8;//内容格式为UTF8 

        SmtpClient client = new SmtpClient();

        client.Host = "smtp.163.com";//SMTP服务器地址 
        client.Port = 25;//SMTP端口，QQ邮箱填写587 

        client.EnableSsl = false;//启用SSL加密 
                                //发件人邮箱账号，授权码(注意此处，是授权码你需要到qq邮箱里点设置开启Smtp服务，然后会提示你第三方登录时密码处填写授权码)
        

        try
        {
            client.Send(msg);//发送邮件
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public bool not_equal(string text1, string text2) //检验两个字符串是否相同
    {
        if (text1 != text2) return true;
        else return false;
    }

    public bool overLength(string text, int limit) //检验是否超长
    {
        if (text.Length > limit) return true;
        else return false;
    }

    public bool non_string_existed(string text, string judge) //检验是否不存在一个特殊的判断字符
    {
        int j = text.IndexOf(judge);
        if (j == -1) return true;
        else return false;
    }

    public bool nullString(string text) //判断一个字符串是否为空
    {
        if (text != "" && text != null) return false;
        else return true;
    }

    public string generateRandomNum(int length)
    {
        char[] constant =
        {
        '0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
         };
    
        System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
        Random rd = new Random();
        for (int i = 0; i < length; i++)
        {
            newRandom.Append(constant[rd.Next(62)]);
        }
        return newRandom.ToString();
    }
}
