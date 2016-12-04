using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities;
using Workbook.BLL.Services.Interfaces;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;

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
        public UserDTO GetAuthorizedUser(string login, string password)
        {
            string hashPassword;
            UserDTO user = _userService.Find(x => x.Login == login).FirstOrDefault();
            bool isUserExsist = user != null;
            if (!isUserExsist)
            {
                return null;
            }

            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = MD5.Create().ComputeHash(bytes);
            hashPassword = Convert.ToBase64String(hashBytes);


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
    }
}
