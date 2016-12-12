using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;

namespace Supervisor.ViewModels
{
    public class SupervisorDepartmentsViewModel : BindableBase
    {
        private readonly DepartmentService _departmentService;

        public SupervisorDepartmentsViewModel(DepartmentService departmentService)
        {
            _departmentService = departmentService;

            DepartmentsList = new ObservableCollection<DepartmentDTO>(_departmentService.FindAll());

            if (DepartmentsList.Any())
            {
                SelectedDepartment = DepartmentsList.First();
            }

            SaveSelectedItem = new DelegateCommand<object>(SaveSelected, (x) => true);
            RemoveSelectedItem = new DelegateCommand<object>(RemoveSelected, (x) => true);
            AddNewItem = new DelegateCommand<object>(AddNew, (x) => true);
        }

        public ObservableCollection<DepartmentDTO> DepartmentsList { get; set; }

        private DepartmentDTO _selectedDepartment;
        public DepartmentDTO SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewItem { get; }
        public ICommand SaveSelectedItem { get; }
        public ICommand RemoveSelectedItem { get; }

        private void AddNew(object obj)
        {
            SelectedDepartment = new DepartmentDTO();
        }
        private void SaveSelected(object obj)
        {

            if (_selectedDepartment.Id == Guid.Empty)
            {
                _departmentService.Add(_selectedDepartment);
                DepartmentsList.Add(_selectedDepartment);
            }
            else
            {
                _departmentService.Update(_selectedDepartment);
            }

        }
        private void RemoveSelected(object obj)
        {
            _departmentService.Remove(_selectedDepartment);
            DepartmentsList.Remove(_selectedDepartment);
            SelectedDepartment = DepartmentsList.FirstOrDefault();
        }
    }
}
