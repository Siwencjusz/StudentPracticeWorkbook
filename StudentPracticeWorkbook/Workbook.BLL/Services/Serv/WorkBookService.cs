using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.EntityFramework;

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
