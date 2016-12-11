using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Security;
using AutoMapper;
using LaboratoryHandbook.Services;
using ProjectEstimator.DAL.Entities.Roles;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.BLL.Services.Serv;
using Workbook.Commons;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework;
using Workbook.DAL.EntityFramework.Repositories;

namespace Workbook.BLL.Services.Serv
{
    public sealed class UserService : BaseService<User, UserDTO>, IUserService
    {
        private readonly IUserRepository _baseRepository;
        private readonly IRoleRepository _roleService;
        private readonly IWorkBookRepository _workBookRepository;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        private SmtpClient _smtpClient;

        public UserService(IUserRepository baseRepository, IRoleRepository roleService, IWorkBookRepository workBookRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _roleService = roleService;
            _workBookRepository = workBookRepository;
        }

        public override void Add(UserDTO item)
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
            //SendEmail(item.Email, subject, body);

            item.Login = item.Email;
            User user=null;
            Role role=null;
            switch (item.Role.Name)
            {
                case "Student":
                    user = Mapper.Map<Student>(item);
                    role = _roleService.FindById(user.RoleId.Value);
                    user.Role = role;
                    user.RoleId = role.Id;
                    //user.Role = null;
                    //user.RoleId = null;
                    _baseRepository.Add(user); break;
                case "Admin":
                    user = Mapper.Map<User>(item);
                    role = _roleService.FindById(user.RoleId.Value);
                    user.Role = role;
                    user.RoleId = role.Id;
                    _baseRepository.Add(user); break;
                case "Firma":
                    user = Mapper.Map<Company>(item);
                    role = _roleService.FindById(user.RoleId.Value);
                    user.Role = role;
                    user.RoleId = role.Id;
                    _baseRepository.Add(user); break;
                case "Opiekun":
                    user = Mapper.Map<Employee>(item);
                    role = _roleService.FindById(user.RoleId.Value);
                    user.Role = role;
                    user.RoleId = role.Id;
                    _baseRepository.Add(user); break;
            }
            _baseRepository.Save();

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


        public override void Remove(UserDTO item)
        {
            if (item.Role.Name=="Admin")
            {
                return;
            }
            var toDelete = _baseRepository.GetBy(x => x.Id == item.Id).FirstOrDefault();
            if (toDelete.Role.Name=="Opiekun")
            {
                var  relatedWorkbooks= _workBookRepository.GetBy(x => x.EmployeeId == toDelete.Id);
                foreach (var workbook in relatedWorkbooks)
                {
                    workbook.EmployeeId = null;
                    workbook.Employee = null;
                    _workBookRepository.Edit(workbook);
                }
                _workBookRepository.Save();
            }

            toDelete = _baseRepository.GetBy(x => x.Id == item.Id).FirstOrDefault();
            _baseRepository.Delete(toDelete);
            _baseRepository.Save();
        }

        public override void Update(UserDTO item)
        {
            var user = _baseRepository.FindById(item.Id);
            Role x = null;
            Department y = null;
            if (item.Role != null)
            {
                x = _roleService.FindById(item.Role.Id);
            }
            
            item.Role = null;

            if (x != null)
            {
                user.Role = x;
                user.RoleId = x.Id;
            }
            user.Email = item.Email;
            user.Name= item.Name;
            user.Login = item.Login;
            

            _baseRepository.Edit(user);
        }
    }
}
