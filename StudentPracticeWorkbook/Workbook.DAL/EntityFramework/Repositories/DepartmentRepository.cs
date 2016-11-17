using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEstimator.DAL.Base.BaseRepository;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework.baseRepository;

namespace Workbook.DAL.EntityFramework.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(StudentWorkBookContext context) : base(context)
        {
        }
    }
}
