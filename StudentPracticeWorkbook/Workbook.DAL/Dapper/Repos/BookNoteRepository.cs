using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Dapper.BaseRepo;
using Workbook.DAL.Dapper.Interfaces;
using Workbook.DAL.Entities;

namespace Workbook.DAL.Dapper.Repos
{
    public sealed class BookNoteRepository : BaseRepository<BookNote>, IBookNoteRepository
    {
        public BookNoteRepository() : base("BookNotes")
        {

        }
    }
}
