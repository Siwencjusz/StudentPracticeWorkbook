using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using User.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Admin.ViewModels
{
    public class AdminStudentsViewModel : BindableBase
    {
        private readonly UserService _userService;

        public AdminStudentsViewModel(UserService userService)
        {
            _userService = userService;

            StudentsList = new ObservableCollection<Workbook.DAL.Entities.User>(_userService.FindAll());

            StudentsList.Add(new Workbook.DAL.Entities.User()
            {
                
            });
        }

        public ObservableCollection<Workbook.DAL.Entities.User> StudentsList { get; set; }
    }
}
