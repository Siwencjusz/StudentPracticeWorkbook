using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Serv;

namespace Company.ViewModels
{
    public class CompanyInternsViewModel : BindableBase
    {
        private readonly UserService _userService;

        public CompanyInternsViewModel(UserService userService)
        {
            _userService = userService;
            InternsList = new ObservableCollection<UserDTO>(_userService.FindAll());
        }

        private ObservableCollection<UserDTO> InternsList { get; set; }
    }
}
