using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Workbook.Commons;

namespace Admin
{
    public class AdminModule : IModule
    {
        IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public AdminModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(Views.AdminMenuView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.AdminCompaniesView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.AdminDepartmentsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.AdminStudentsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.AdminWorkbooksView));
        }
    } 
}