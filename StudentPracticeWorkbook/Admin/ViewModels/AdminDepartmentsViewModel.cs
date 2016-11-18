using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Admin.ViewModels
{
    public class AdminDepartmentsViewModel : BindableBase
    {
        private readonly DepartmentService _departmentService;

        public AdminDepartmentsViewModel(DepartmentService departmentService)
        {
            _departmentService = departmentService;

            DepartmentsList = new ObservableCollection<Department>(_departmentService.FindAll());
        }

        public ObservableCollection<Department> DepartmentsList { get; set; }

    }
}
