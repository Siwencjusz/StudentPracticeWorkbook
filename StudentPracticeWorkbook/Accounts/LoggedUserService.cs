using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Interfaces;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Accounts
{
    public class LoggedUserService
    {
        private readonly IUserService _userService;

        public LoggedUserService(IUnityContainer container)
        {
            _userService = container.Resolve<UserService>();
        }

        public bool UserIsLogged = false;

        private UserDTO _activeUser = null;

        public UserDTO ActiveUser
        {
            get { return _activeUser; }
            set { _activeUser = value; }
        }

    }
}
