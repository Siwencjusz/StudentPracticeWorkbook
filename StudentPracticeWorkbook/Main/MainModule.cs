using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Workbook.Commons;

namespace Main
{
    public class MainModule : IModule
    {
        IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public MainModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            //_container.RegisterType<Views.Main>();
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.Main));
            //_regionManager.Regions[RegionNames.ContentRegion].Add(_container.Resolve<Views.Main>());
        }
    }
}