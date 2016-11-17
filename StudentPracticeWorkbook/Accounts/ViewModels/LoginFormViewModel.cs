using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Accounts.Views;
using Admin;
using Admin.Views;
using Company;
using Company.Views;
using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using Student;
using Student.Views;
using Supervisor;
using Supervisor.Views;
using Workbook.BLL.Services;
using Workbook.BLL.Services.Serv;
using Workbook.Commons;
using Workbook.DAL.Dapper.Repos;

namespace Accounts.ViewModels
{
    public class LoginFormViewModel
    {
        private readonly RegionManager _regionManager;
        private readonly LoggedUserService _loggedUserService;
        private readonly ModuleManager _moduleManager;
        private readonly AuthorizeService _authorizeService;

        public LoginFormViewModel(RegionManager regionManager, LoggedUserService loggedUserService, ModuleManager moduleManager, AuthorizeService authorizeService)
        {
            _regionManager = regionManager;
            _loggedUserService = loggedUserService;
            _moduleManager = moduleManager;
            _authorizeService = authorizeService;
        }

        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _pw;

        public string Pw
        {
            get { return _pw; }
            set { _pw = value; }
        }

        public ICommand LogIn
        {
            get { return new DelegateCommand<object>(OnLoginHit, (x) => true); }
        }

        private void OnLoginHit(object obj)
        {

            var x=_authorizeService.GetAuthorizedUser(_id, _pw);

            if (x == null)
            {
                return;
            }

            _loggedUserService.ActiveUser = x;

            if (x.Role.Name == AppRoles.Opiekun.ToString())
            {
                _moduleManager.LoadModule(typeof(SupervisorModule).Name);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(SupervisorStudentsView).ToString());
                _regionManager.RequestNavigate(RegionNames.MenuRegion, typeof(SupervisorMenuView).ToString());
            }else if (x.Role.Name == AppRoles.Admin.ToString())
            {
                _moduleManager.LoadModule(typeof(AdminModule).Name);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(AdminCompaniesView).ToString());
                _regionManager.RequestNavigate(RegionNames.MenuRegion, typeof(AdminMenuView).ToString());
            }else if (x.Role.Name == AppRoles.Firma.ToString())
            {
                _moduleManager.LoadModule(typeof(CompanyModule).Name);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(CompanyDepartmentsView).ToString());
                _regionManager.RequestNavigate(RegionNames.MenuRegion, typeof(CompanyMenuView).ToString());
            }else if (x.Role.Name == AppRoles.Student.ToString())
            {
                _moduleManager.LoadModule(typeof(StudentModule).Name);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(StudentCompaniesView).ToString());
                _regionManager.RequestNavigate(RegionNames.MenuRegion, typeof(StudentMenuView).ToString());
            }
            else
            {
                return;
            }


            _regionManager.RequestNavigate(RegionNames.NavRegion, typeof(AccountToolbar).ToString());

            _loggedUserService.UserIsLogged = true;
        }

    }
}
