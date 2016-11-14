using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Supervisor.Views;
using Workbook.Commons;

namespace Supervisor
{
    public class SupervisorModule : IModule
    {
        IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public SupervisorModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(Views.SupervisorMenuView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.SupervisorCompaniesView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.SupervisorDepartmentsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.SupervisorStudentsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.SupervisorWorkbooksView));

        }
    }
}