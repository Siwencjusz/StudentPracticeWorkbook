using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Workbook.Commons;

namespace Student
{
    public class StudentModule : IModule
    {
        IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public StudentModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(Views.StudentMenuView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.StudentCompaniesView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.StudentWorkbooksView));

        }
    }
}