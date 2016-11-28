using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework;

namespace Workbook.BLL.Services.Serv
{
    public sealed class WorkBookService : BaseService<DAL.Entities.Workbook, WorkbookDTO>,IWorkBookService
    {
        private readonly IWorkBookRepository _baseRepository;

        public WorkBookService(IWorkBookRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
