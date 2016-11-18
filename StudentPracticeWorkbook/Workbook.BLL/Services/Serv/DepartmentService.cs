using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework.baseRepository;

namespace Workbook.BLL.Services.Serv
{
    public sealed class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _baseRepository;

        public DepartmentService(IDepartmentRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
