using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.Dapper.Repos;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    public sealed class WorkBookService : BaseService<DAL.Entities.WorkBook>,IWorkBookService
    {
        private readonly IWorkBookRepository _baseRepository;

        public WorkBookService(IWorkBookRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
