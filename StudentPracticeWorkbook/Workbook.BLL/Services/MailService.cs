using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using LaboratoryHandbook.Services;

public class MailService : IMailService
{
    private readonly string _sender;
    private SmtpClient _smtpClient;
    private string _title;
    private string _body;
    private MailMessage _mail;

    public MailService()
    {
        _sender = "StudentWorkBookService@gmail.com";
        var smtpServer = "smtp.gmail.com";
        var smtpPort = 587;
        var smtpUser = "StudentWorkBookService@gmail.com";
        var smtpPassword = "3edc$RFV";
        _smtpClient = new SmtpClient(smtpServer, smtpPort);
        _smtpClient.EnableSsl = true;

        NetworkCredential credential = new NetworkCredential(smtpUser, smtpPassword);
        _smtpClient.Credentials = credential;
    }

    public bool Send(string to)
    {
        if (_mail == null)
        {
            _mail = new MailMessage(_sender, to);
        }
        else
        {
            _mail.From = new MailAddress(_sender);
            _mail.To.Add(new MailAddress(to));
        }
        _mail.IsBodyHtml = false;
        try
        {
            _smtpClient.Send(_mail);
        }
        catch (Exception e)
        {
            return false;
        }
        _mail.Dispose();
        _mail = null;
        return true;
    }

    public void Attach(Attachment item)
    {
        if (_mail == null)
        {
            _mail = new MailMessage();
        }
        _mail.Attachments.Add(item);
    }

    public void setContent(EmailContent EmailContent)
    {
        _title = EmailContent.Title;
        _body = EmailContent.Body;
    }
}