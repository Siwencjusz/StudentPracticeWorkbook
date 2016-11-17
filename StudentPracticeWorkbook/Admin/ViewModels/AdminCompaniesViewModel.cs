using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using User.BLL.Services.Serv;

namespace Admin.ViewModels
{
    public class AdminCompaniesViewModel : BindableBase
    {
        private readonly UserService _userService;

        public AdminCompaniesViewModel(UserService userService)
        {
            _userService = userService;
            CompaniesList = new ObservableCollection<Workbook.DAL.Entities.User>(_userService.FindAll());
        }

        public ObservableCollection<Workbook.DAL.Entities.User> CompaniesList { get; set; }
    }
}
