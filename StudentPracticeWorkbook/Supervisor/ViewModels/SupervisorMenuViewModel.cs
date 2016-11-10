using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ModulesCommons;
using Prism.Regions;

namespace Supervisor.ViewModels
{
    public class SupervisorMenuViewModel : MenuViewModelBase
    {
        public SupervisorMenuViewModel(RegionManager regionManager) : base(regionManager)
        {

        }
    }
}
