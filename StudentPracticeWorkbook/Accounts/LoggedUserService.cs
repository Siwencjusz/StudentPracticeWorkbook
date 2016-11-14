using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using User.BLL.Services.Serv;
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

        private Workbook.DAL.Entities.User _activeUser = null;

        public string LoggedUser
        {
            get
            {
                if (_activeUser != null)
                {
                    return _activeUser.Login;
                }
                return "Niezalogowany";
            }
        }
    }
}
