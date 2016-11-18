using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities;
using Workbook.BLL.Services.Interfaces;
using User.BLL.Services.Serv;
using Workbook.BLL.Services.Serv;
using User = Workbook.DAL.Entities.User;

namespace Workbook.BLL.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        public AuthorizeService(UserService userService, RoleService roleService, DepartmentService departmentService)
        {
            _userService = userService;
            _roleService = roleService;
            _departmentService = departmentService;
        }

        private readonly UserService _userService;
        private readonly RoleService _roleService;
        private readonly DepartmentService _departmentService;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        public DAL.Entities.User GetAuthorizedUser(string login, string password)
        {
            string hashPassword;
            DAL.Entities.User user = _userService.Find(x => x.Login == login).FirstOrDefault();
            bool isUserExsist = user != null;
            if (!isUserExsist)
            {
                return null;
            }
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(
            System.Text.Encoding.UTF8.GetBytes(password)))
            {
                hashPassword = System.Text.Encoding.Default.GetString(md5.ComputeHash(ms));
            }
            bool isPasswordOk = (user.HashPassword == hashPassword);
            if (!isPasswordOk)
            {
                return null;
            }
            if (isUserExsist && isPasswordOk)
            {
                return user;
            }
            return null;
        }


        //public bool IsUserCredentialMatched(string login, string password)
        //{
        //    string hashPassword;
        //    var user = _userService.Find(x => x.Login == login).FirstOrDefault();
        //    bool isUserExsist = user != null;
        //    if (!isUserExsist)
        //    {
        //        return false;
        //    }
        //    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(
        //    System.Text.Encoding.UTF32.GetBytes(password)))
        //    {
        //        hashPassword = md5.ComputeHash(ms).ToString();
        //    }
        //    bool isPasswordOk = user.HashPassword == hashPassword;
        //    if (!isPasswordOk)
        //    {
        //        return false;
        //    }
        //    if (isUserExsist && isPasswordOk)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
