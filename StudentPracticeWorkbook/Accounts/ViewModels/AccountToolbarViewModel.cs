using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Accounts.Views;
using Admin.Views;
using Company;
using Company.Views;
using Prism.Modularity;
using Prism.Regions;
using Student;
using Student.Views;
using Supervisor;
using Supervisor.Views;
using Workbook.Commons;

namespace Accounts.ViewModels
{
    public class AccountToolbarViewModel : BindableBase
    {
        private readonly RegionManager _regionManager;
        private readonly LoggedUserService _loggedUserService;
        private readonly ModuleManager _moduleManager;

        public AccountToolbarViewModel(RegionManager regionManager, LoggedUserService loggedUserService, ModuleManager moduleManager)
        {
            _regionManager = regionManager;
            _loggedUserService = loggedUserService;
            _moduleManager = moduleManager;
        }



        public string LoggedUser
        {
            get { return _loggedUserService.LoggedUser; }
            set { SetProperty(ref _loggedUserService.LoggedUser, value); }
        }


        public string UserIsLoggedButtonString => _loggedUserService.UserIsLogged ? "Wyloguj" : "Zaloguj";

        public bool UserIsLogged
        {
            get { return _loggedUserService.UserIsLogged; }
            set
            {
                _loggedUserService.UserIsLogged = value;
                OnPropertyChanged(nameof(UserIsLoggedButtonString));
            }
        }

        public ICommand LogInOrOut
        {
            get { return new DelegateCommand<object>(OnLoginHit, (x)=>true); }
        }

        private void OnLoginHit(object obj)
        {
            if (_loggedUserService.UserIsLogged)
            {
                UserIsLogged = false;
                _moduleManager.LoadModule(typeof(SupervisorModule).Name);
                _regionManager.RequestNavigate(RegionNames.MenuRegion, typeof(SupervisorMenuView).ToString());
            }
            else
            {
                UserIsLogged = true;
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(LoginForm).ToString());
                _regionManager.RequestNavigate(RegionNames.MenuRegion, typeof(LoginMenuView).ToString());
            }
        }
    }
}
