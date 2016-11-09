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
using Prism.Regions;
using Workbook.Commons;

namespace Accounts.ViewModels
{
    public class AccountToolbarViewModel : BindableBase
    {
        private readonly RegionManager _regionManager;
        private readonly LoggedUserService _loggedUserService;

        public AccountToolbarViewModel(RegionManager regionManager, LoggedUserService loggedUserService)
        {
            _regionManager = regionManager;
            _loggedUserService = loggedUserService;
        }



        public string LoggedUser
        {
            get { return _loggedUserService.LoggedUser; }
            set { SetProperty(ref _loggedUserService.LoggedUser, value); }
        }


        public string UserIsLoggedButtonString => _loggedUserService.UserIsLogged ? "Zaloguj" : "Wyloguj";

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
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(LoginForm).ToString());
            }
            else
            {
                UserIsLogged = true;
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(Main.Views.Main).ToString());
            }
        }
    }
}
