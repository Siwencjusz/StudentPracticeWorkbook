using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEstimator.DAL.Base.BaseRepository;
using Workbook.DAL.Entities;

namespace Workbook.DAL.EntityFramework.Repositories
{
    public class WorkBookRepository : BaseRepository<Entities.Workbook>, IWorkBookRepository
    {
        public WorkBookRepository(StudentWorkBookContext context) : base(context)
        {
        }

        public override Entities.Workbook Add(Entities.Workbook entity)
        {
            entity.Department = null;
            entity.Company = null;
            entity.Employee = null;
            entity.Student = null;
            return base.Add(entity);
        }
        
    }
}
