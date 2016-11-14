using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Workbook.Prism.Views;
using System.Windows;
using Accounts;
using Admin;
using Company;
using Main;
using Prism.Modularity;
using Student;
using Supervisor;

namespace Workbook.Prism
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

        }

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
               // typeof(MainModule),
                //typeof(AccountsModule),
                typeof(AdminModule),
                typeof(CompanyModule),
                typeof(StudentModule),
                typeof(SupervisorModule)
            };

            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = typeof(AccountsModule).Name,
                ModuleType = typeof(AccountsModule).AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

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
                    InitializationMode = InitializationMode.OnDemand
                });
            }
        }
    }
}
