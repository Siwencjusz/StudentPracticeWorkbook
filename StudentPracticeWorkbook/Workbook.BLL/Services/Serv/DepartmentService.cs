using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;

namespace Workbook.BLL.Services.Serv
{
    public sealed class DepartmentService : BaseService<Workbook.DAL.Entities.Department>, IDepartmentService
    {
        private readonly IRepository<Workbook.DAL.Entities.Department> _baseRepository;

        public DepartmentService(IRepository<Workbook.DAL.Entities.Department> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
