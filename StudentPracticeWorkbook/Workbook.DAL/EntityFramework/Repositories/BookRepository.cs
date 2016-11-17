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
    public class BookNoteRepository : BaseRepository<BookNote>, IBookNoteRepository
    {
        public BookNoteRepository(StudentWorkBookContext context) : base(context)
        {
        }
    }
}
