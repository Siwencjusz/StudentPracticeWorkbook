using Prism.Modularity;
using Prism.Regions;
using System;
using System.Security.AccessControl;
using Accounts.Views;
using Microsoft.Practices.Unity;
using Workbook.Commons;

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
            _container.RegisterType<LoggedUserService>(new ContainerControlledLifetimeManager());

            _container.RegisterType<AccountToolbar>();
            _regionManager.RegisterViewWithRegion(RegionNames.NavRegion, typeof(AccountToolbar));
            _regionManager.Regions[RegionNames.NavRegion].Add(_container.Resolve<AccountToolbar>());

            _container.RegisterType<LoginForm>();
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(LoginForm));
            _regionManager.Regions[RegionNames.ContentRegion].Add(_container.Resolve<LoginForm>());
        }
    }
}