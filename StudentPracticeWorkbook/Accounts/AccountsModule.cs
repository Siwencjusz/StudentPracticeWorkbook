using Prism.Modularity;
using Prism.Regions;
using System;
using System.ComponentModel;
using System.Security.AccessControl;
using Accounts.Views;
using Microsoft.Practices.Unity;
using User.BLL.Services.Serv;
using Workbook.Commons;
using Workbook.DAL.Dapper.Interfaces;
using Workbook.DAL.Dapper.Repos;

namespace Accounts
{
    public class AccountsModule : IModule
    {
        IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public AccountsModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());

            _container.RegisterType<LoggedUserService>(new ContainerControlledLifetimeManager());

            _regionManager.RegisterViewWithRegion(RegionNames.NavRegion, typeof(LoginToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.NavRegion, typeof(AccountToolbar));
            
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(LoginForm));

            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(LoginMenuView));
        }
    }
}