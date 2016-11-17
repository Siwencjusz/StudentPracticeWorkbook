using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Workbook.BLL.Services.Serv;
using Workbook.DAL.Entities;

namespace Admin.ViewModels
{
    public class AdminWorkbooksViewModel : BindableBase
    {
        private readonly WorkBookService _workBookService;

        public AdminWorkbooksViewModel(WorkBookService workBookService)
        {
            _workBookService = workBookService;
            WorkbooksList = new ObservableCollection<WorkBook>(_workBookService.FindAll());
        }

        public ObservableCollection<WorkBook> WorkbooksList { get; set; }
    }
}
