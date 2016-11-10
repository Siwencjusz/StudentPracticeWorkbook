using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Workbook.Commons;

namespace ModulesCommons
{
    public class MenuViewModelBase : BindableBase
    {
        private readonly RegionManager _regionManager;

        public MenuViewModelBase(RegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigationCommand = new DelegateCommand<object>(OnNavHit, (x) => true);

        }

        public ICommand NavigationCommand { get; }

        private void OnNavHit(object obj)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, obj.ToString());
        }
    }
}
