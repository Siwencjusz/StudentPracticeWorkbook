using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    public sealed class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IRepository<Department> _baseRepository;

        public DepartmentService(IRepository<Department> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
