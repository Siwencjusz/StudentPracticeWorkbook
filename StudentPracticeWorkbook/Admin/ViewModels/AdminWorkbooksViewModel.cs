using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;
using Workbook.Commons;
using Workbook.DAL.Entities;

namespace Admin.ViewModels
{
    public class AdminWorkbooksViewModel : BindableBase
    {
        private readonly WorkBookService _workBookService;
        private readonly UserService _userService;
        private readonly DepartmentService _departmentService;

        public AdminWorkbooksViewModel(
            WorkBookService workBookService,
            UserService userService,
            DepartmentService departmentService
            )
        {
            _workBookService = workBookService;
            _userService = userService;
            _departmentService = departmentService;

            WorkbooksList = new ObservableCollection<WorkbookDTO>(_workBookService.FindAll());
            StudentsList = new ObservableCollection<UserDTO>(_userService.Find(x=>x.Role.Name == AppRoles.Student.ToString()));
            SupervisorsList = new ObservableCollection<UserDTO>(_userService.Find(x => x.Role.Name == AppRoles.Opiekun.ToString()));
            CompaniesList = new ObservableCollection<UserDTO>(_userService.Find(x => x.Role.Name == AppRoles.Firma.ToString()));
            DepartmentsList = new ObservableCollection<DepartmentDTO>(_departmentService.FindAll());

            if (WorkbooksList.Any())
            {
                SelectedWorkBook = WorkbooksList.First();
            }

            SaveSelectedItem = new DelegateCommand<object>(SaveSelected, (x) => true);
            RemoveSelectedItem = new DelegateCommand<object>(RemoveSelected, (x) => true);
            AddNewItem = new DelegateCommand<object>(AddNew, (x) => true);
        }

        private WorkbookDTO _selectedWorkBook;
        public WorkbookDTO SelectedWorkBook
        {
            get
            {
                return _selectedWorkBook;
            }
            set
            {
                _selectedWorkBook = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WorkbookDTO> WorkbooksList { get; set; }
        public ObservableCollection<UserDTO> StudentsList { get; set; }
        public ObservableCollection<UserDTO> SupervisorsList { get; set; }
        public ObservableCollection<UserDTO> CompaniesList { get; set; }
        public ObservableCollection<DepartmentDTO> DepartmentsList { get; set; }

        public ICommand AddNewItem { get; }
        public ICommand SaveSelectedItem { get; }
        public ICommand RemoveSelectedItem { get; }

        private void AddNew(object obj)
        {
            SelectedWorkBook = new WorkbookDTO();
        }
        private void SaveSelected(object obj)
        {

            if (_selectedWorkBook.Id == Guid.Empty)
            {
                _workBookService.Add(_selectedWorkBook);
                WorkbooksList.Add(_selectedWorkBook);
            }
            else
            {
                _workBookService.Update(_selectedWorkBook);
            }

        }
        private void RemoveSelected(object obj)
        {
            _workBookService.Remove(_selectedWorkBook);
            WorkbooksList.Remove(_selectedWorkBook);
            _selectedWorkBook = null;
        }
    }
}
