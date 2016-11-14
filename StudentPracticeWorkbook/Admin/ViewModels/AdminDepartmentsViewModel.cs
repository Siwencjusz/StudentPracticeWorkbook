using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Workbook.DAL.Entities;

namespace Admin.ViewModels
{
    public class AdminDepartmentsViewModel : BindableBase
    {
        public AdminDepartmentsViewModel()
        {
            DepartmentsList.Add(new Department()
            {
                Name = "dep1"
            });
            DepartmentsList.Add(new Department()
            {
                Name = "dep2"
            });
            DepartmentsList.Add(new Department()
            {
                Name = "dep3"
            });

        }

        public ObservableCollection<Department> DepartmentsList = new ObservableCollection<Department>();
    }
}
