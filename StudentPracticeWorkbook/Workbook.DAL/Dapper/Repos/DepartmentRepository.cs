using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Dapper.BaseRepo;
using Workbook.DAL.Entities;

namespace Workbook.DAL.Dapper.Repos
{
    public sealed class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository() : base("Department")
        {

        }
    }
}
