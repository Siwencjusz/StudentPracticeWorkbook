using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Security;
using LaboratoryHandbook.Services;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework;

namespace User.BLL.Services.Serv
{
    public sealed class UserService : BaseService<Workbook.DAL.Entities.User>, IUserService
    {
        private readonly IUserRepository _baseRepository;
        private readonly IRoleService _roleService;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        private SmtpClient _smtpClient;

        public UserService(IUserRepository baseRepository, IRoleService roleService) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _roleService = roleService;
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
            var _sender = "StudentWorkBookService@gmail.com";
            var smtpServer = "smtp.gmail.com";
            var smtpPort = 587;
            var smtpUser = "StudentWorkBookService@gmail.com";
            var smtpPassword = "3edc$RFV";
            _smtpClient = new SmtpClient(smtpServer, smtpPort);
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


        public override void Update(Workbook.DAL.Entities.User item)
        {
            Role x = null;
            if (item.Role != null)
            {
                x = _roleService.FindByID(item.Role.Id);
            }
            
            item.Role = null;

            if (x != null)
            {
                item.RoleId = x.Id;
            }
            
            
            _baseRepository.Edit(item);
        }
    }
}
