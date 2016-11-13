using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    public sealed class WorkBookService : BaseService<DAL.Entities.WorkBook>,IWorkBookService
    {
        private readonly IRepository<WorkBook> _baseRepository;

        public WorkBookService(IRepository<WorkBook> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
