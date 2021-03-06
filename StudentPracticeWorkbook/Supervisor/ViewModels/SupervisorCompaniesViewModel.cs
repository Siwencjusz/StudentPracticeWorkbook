﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;
using Workbook.Commons;

namespace Supervisor.ViewModels
{
    public class SupervisorCompaniesViewModel : BindableBase
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public SupervisorCompaniesViewModel(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;

            UsersList = new ObservableCollection<UserDTO>(_userService.Find(x => x.Role.Name == AppRoles.Firma.ToString()));
            Roles = new ObservableCollection<RoleDTO>(_roleService.FindAll());

            if (UsersList.Any())
            {
                SelectedUser = UsersList.First();
            }

            SaveSelectedItem = new DelegateCommand<object>(SaveSelected, (x) => true);
            RemoveSelectedItem = new DelegateCommand<object>(RemoveSelected, (x) => true);
            AddNewItem = new DelegateCommand<object>(AddNew, (x) => true);
        }

        public ObservableCollection<UserDTO> UsersList { get; set; }
        public ObservableCollection<RoleDTO> Roles { get; set; }


        private UserDTO _selectedUser;
        public UserDTO SelectedUser
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
        public ICommand SaveSelectedItem { get; }
        public ICommand RemoveSelectedItem { get; }

        private void AddNew(object obj)
        {
            SelectedUser = new UserDTO();
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
            //UsersList.Remove(_selectedUser);
            _userService.Remove(_selectedUser);
            UsersList = new ObservableCollection<UserDTO>(_userService.FindAll());
            _selectedUser = UsersList.FirstOrDefault();
        }
    }
}
