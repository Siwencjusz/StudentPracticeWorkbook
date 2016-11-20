using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using User.BLL.Services.Serv;
using User = Workbook.DAL.Entities.User;

namespace Admin.ViewModels
{
    public class AdminUsersViewModel : BindableBase
    {
        private readonly UserService _userService;

        public AdminUsersViewModel(UserService userService)
        {
            _userService = userService;
            UsersList = new ObservableCollection<Workbook.DAL.Entities.User>(_userService.FindAll());
            SaveSelectedItem = new DelegateCommand<object>(SaveSelected, (x) => true);
            RemoveSelectedItem = new DelegateCommand<object>(RemoveSelected, (x) => true);
            AddNewItem = new DelegateCommand<object>(AddNew, (x) => true);
        }

        private Workbook.DAL.Entities.User _selectedUser;

        public Workbook.DAL.Entities.User SelectedUser
        {
            get { return _selectedUser; }
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

        public ObservableCollection<Workbook.DAL.Entities.User> UsersList { get; set; }
    }
}
