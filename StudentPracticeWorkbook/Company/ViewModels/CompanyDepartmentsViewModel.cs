using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Company.ViewModels
{
    public class CompanyDepartmentsViewModel : BindableBase
    {
        private readonly DepartmentService _departmentService;

        public CompanyDepartmentsViewModel(DepartmentService departmentService)
        {
            _departmentService = departmentService;
            DepartmentsList = new ObservableCollection<DepartmentDTO>(_departmentService.FindAll());
        }

        public ObservableCollection<DepartmentDTO> DepartmentsList { get; set; }
    }
}
