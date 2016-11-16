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

namespace Workbook.BLL.Services
{
    public class AuthorizeService : IAuthorizeServicecs
    {
        public AuthorizeService(IUserService userService, IRoleService roleService, IDepartmentService departmentService)
        {
            _userService = userService;
            _roleService = roleService;
            _departmentService = departmentService;
        }

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IDepartmentService _departmentService;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        public DAL.Entities.User GetAuthorizedUser(Guid Id)
        {
            var selectedUser = _userService.FindByID(Id);
            if (selectedUser != null)
            {
                selectedUser.Role = _roleService.FindByID(selectedUser.RoleId.Value);
                selectedUser.Department = _departmentService.FindByID(selectedUser.DepartmentId.Value);
            }
            return selectedUser;
        }


        public bool IsUserCredentialMatched(string login, string password)
        {
            string hashPassword;
            var user = _userService.Find(x => x.Login == login).FirstOrDefault();
            bool isUserExsist = user != null;
            if (!isUserExsist)
            {
                return false;
            }
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(
            System.Text.Encoding.UTF32.GetBytes(password)))
            {
                hashPassword = md5.ComputeHash(ms).ToString();
            }
            bool isPasswordOk = user.HashPassword == hashPassword;
            if (!isPasswordOk)
            {
                return false;
            }
            if (isUserExsist && isPasswordOk)
            {
                return true;
            }
            return false;
        }
    }
}
