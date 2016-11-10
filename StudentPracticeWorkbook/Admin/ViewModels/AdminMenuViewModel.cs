using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ModulesCommons;
using Prism.Regions;
using Workbook.Commons;

namespace Admin.ViewModels
{
    public class AdminMenuViewModel : MenuViewModelBase
    {
        public AdminMenuViewModel(RegionManager regionManager) : base(regionManager)
        {
            
        }

    }
}
