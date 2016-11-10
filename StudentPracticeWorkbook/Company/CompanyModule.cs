using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Workbook.Commons;

namespace Company
{
    public class CompanyModule : IModule
    {
        IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public CompanyModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(Views.CompanyMenuView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.CompanyDepartmentsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.CompanyInternsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.CompanyAboutView));
        }
    }
}