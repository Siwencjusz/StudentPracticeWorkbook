using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Security;
using LaboratoryHandbook.Services;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.EntityFramework;

namespace User.BLL.Services.Serv
{
    public sealed class UserService : BaseService<Workbook.DAL.Entities.User>, IUserService
    {
        private readonly IUserRepository _baseRepository;
        private readonly IMailService _imailService;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public UserService(IUserRepository baseRepository, IMailService imailService) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _imailService = imailService;
        }

        public override void Add(Workbook.DAL.Entities.User item)
        {
            var password= Membership.GeneratePassword(6, 3) + "Zaq1@";
            item.HashPassword = password;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(
            System.Text.Encoding.UTF32.GetBytes(item.HashPassword)))
            {
                item.HashPassword = md5.ComputeHash(ms).ToString();
            }

            var subject = "Twoje konto W do dziennika praktyk";
            var body = "Twoje Tymczasowe hasło to: " + password;
            SendEmail(item.Email, subject, body);
            _baseRepository.Add(item);
        }
        private bool SendEmail(string email, string subject, string body)
        {
            MailMessage _mail = new MailMessage();
            _mail.Subject = subject;
            _mail.Body = body;
            var _sender = ConfigurationManager.AppSettings["from"].ToString();
            var smtpServer = ConfigurationManager.AppSettings["smtp_server"].ToString();
            var smtpPort = int.Parse(ConfigurationManager.AppSettings["smtp_port"]);
            var smtpUser = ConfigurationManager.AppSettings["smtp_user"].ToString();
            var smtpPassword = ConfigurationManager.AppSettings["smtp_password"].ToString();
            var _smtpClient = new SmtpClient(smtpServer, smtpPort);
            _smtpClient.EnableSsl = true;

            NetworkCredential credential = new NetworkCredential(smtpUser, smtpPassword);
            _smtpClient.Credentials = credential;
            {
                if (_mail == null)
                {
                    _mail = new MailMessage(_sender, email);
                }
                else
                {
                    _mail.From = new MailAddress(_sender);
                    _mail.To.Add(new MailAddress(email));
                }
                _mail.IsBodyHtml = false;
                try
                {
                    _smtpClient.Send(_mail);
                }
                catch (Exception e)
                {
                    var x = e.ToString();
                    return false;
                }
                _mail.Dispose();
                _mail = null;
                return true;
            }
        }

    }
}
