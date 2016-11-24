using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using User.BLL.Services.Serv;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Admin.ViewModels
{
    public class AdminUsersViewModel : BindableBase
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public AdminUsersViewModel(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;

            UsersList = new ObservableCollection<Workbook.DAL.Entities.User>(_userService.FindAll());
            Roles = new ObservableCollection<Role>(_roleService.FindAll());

            if (UsersList.Any())
            {
                SelectedUser = UsersList.First();
            }

            SaveSelectedItem = new DelegateCommand<object>(SaveSelected, (x) => true);
            RemoveSelectedItem = new DelegateCommand<object>(RemoveSelected, (x) => true);
            AddNewItem = new DelegateCommand<object>(AddNew, (x) => true);
        }

        public ObservableCollection<Workbook.DAL.Entities.User> UsersList { get; set; }
        public ObservableCollection<Role> Roles { get; set; }


        private Workbook.DAL.Entities.User _selectedUser;
        public Workbook.DAL.Entities.User SelectedUser
        {
            get
            {
                if (_selectedUser.Role != null)
                {
                    _selectedUser.Role = Roles.FirstOrDefault(x => x.Name == _selectedUser.Role.Name);
                }
                
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewItem { get; }
        public ICommand SaveSelectedItem { get;}
        public ICommand RemoveSelectedItem { get; }

        private void AddNew(object obj)
        {
            SelectedUser = new Workbook.DAL.Entities.User();
        }
        private void SaveSelected(object obj)
        {

            if (_selectedUser.Id == Guid.Empty)
            {
                _userService.Add(_selectedUser);
                UsersList.Add(_selectedUser);
            }
            else
            {
                _userService.Update(_selectedUser);
            }
            
        }
        private void RemoveSelected(object obj)
        {
            _userService.Remove(_selectedUser);
            UsersList.Remove(_selectedUser);
            _selectedUser = null;
        }
    }
}
