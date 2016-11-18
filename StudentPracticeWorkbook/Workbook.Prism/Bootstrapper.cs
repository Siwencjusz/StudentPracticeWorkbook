using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Workbook.Prism.Views;
using System.Windows;
using Accounts;
using Admin;
using Company;
using Prism.Modularity;
using ProjectEstimator.DAL.Entities.Roles;
using ProjectEstimator.DAL.Repositories;
using Student;
using Supervisor;
using User.BLL.Services.Serv;
using Workbook.BLL.Services;
using Workbook.BLL.Services.Interfaces;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.EntityFramework;
using Workbook.DAL.EntityFramework.baseRepository;
using Workbook.DAL.EntityFramework.Repositories;

namespace Workbook.Prism
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IBookNoteRepository, BookNoteRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDepartmentRepository, DepartmentRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRoleRepository, RoleRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWorkBookRepository, WorkBookRepository>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRoleService, RoleService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDepartmentService, DepartmentService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAuthorizeService, AuthorizeService>(new ContainerControlledLifetimeManager());


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
