using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Workbook.Prism.Views;
using System.Windows;
using Accounts;
using Main;
using Prism.Modularity;

namespace Workbook.Prism
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            List<Type> ModulesList = new List<Type>()
            {
                typeof(MainModule),
                typeof(AccountsModule)
            };

            AddModules(ModulesList);
        }

        private void AddModules(List<Type> modules)
        {
            foreach (Type module in modules)
            {
                ModuleCatalog.AddModule(new ModuleInfo()
                {
                    ModuleName = module.Name,
                    ModuleType = module.AssemblyQualifiedName,
                    InitializationMode = InitializationMode.WhenAvailable
                });
            }
        }
    }
}
