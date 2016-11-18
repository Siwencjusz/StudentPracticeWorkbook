using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using User.BLL.Services.Serv;

namespace Company.ViewModels
{
    public class CompanyInternsViewModel : BindableBase
    {
        private readonly UserService _userService;

        public CompanyInternsViewModel(UserService userService)
        {
            _userService = userService;
            InternsList = new ObservableCollection<Workbook.DAL.Entities.User>(_userService.FindAll());
        }

        private ObservableCollection<Workbook.DAL.Entities.User> InternsList { get; set; }
    }
}
