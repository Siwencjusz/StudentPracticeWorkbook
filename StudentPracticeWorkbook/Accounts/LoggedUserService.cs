using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using User.BLL.Services.Serv;
using Workbook.BLL.Services.Interfaces;
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

        public Workbook.DAL.Entities.User ActiveUser
        {
            get { return _activeUser; }
            set { _activeUser = value; }
        }

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
