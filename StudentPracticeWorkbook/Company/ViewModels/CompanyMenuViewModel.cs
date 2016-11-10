using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Primitives;
using ModulesCommons;
using Prism.Regions;

namespace Company.ViewModels
{
    public class CompanyMenuViewModel : MenuViewModelBase
    {
        public CompanyMenuViewModel(RegionManager regionManager) : base(regionManager)
        {

        }
    }
}
