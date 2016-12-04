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
    }
}
