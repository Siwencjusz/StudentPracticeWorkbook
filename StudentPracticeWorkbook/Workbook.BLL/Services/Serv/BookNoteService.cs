using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework.baseRepository;

namespace Workbook.BLL.Services.Serv
{
    namespace Workbook.BLL.Services.Serv
    {
        public sealed class BookNoteService : BaseService<BookNote, BookNoteDTO>, IBookNoteService
        {
            private readonly IBookNoteRepository _baseRepository;

            public BookNoteService(IBookNoteRepository baseRepository) : base(baseRepository)
            {
                _baseRepository = baseRepository;
            }
        }
    }
}
