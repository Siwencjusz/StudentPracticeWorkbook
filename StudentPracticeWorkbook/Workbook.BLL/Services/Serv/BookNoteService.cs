using System;
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

            public override void Add(BookNoteDTO item)
            {
                if (item.Workbook == null)
                {
                    return;
                }
                var note = new BookNote();
                note.FinishDate = item.FinishDate== DateTime.MinValue ? DateTime.Now : item.FinishDate;
                note.StartDate = item.StartDate == DateTime.MinValue ? DateTime.Now : item.StartDate;
                note.Workbook = null;
                note.WorkBookId = item.Workbook.Id;
                note.Note = item.Note;

                _baseRepository.Add(note);
                _baseRepository.Save();
            }

            public override void Update(BookNoteDTO item)
            {
                if (item.Workbook == null)
                {
                    return;
                }
                var note = _baseRepository.FindById(item.Id);
                note.FinishDate = item.FinishDate == DateTime.MinValue ? DateTime.Now : item.FinishDate;
                note.StartDate = item.StartDate == DateTime.MinValue ? DateTime.Now : item.StartDate;
                note.Workbook = null;
                note.WorkBookId = item.Workbook.Id;
                note.Note = item.Note;
                _baseRepository.Edit(note);
                _baseRepository.Save();
            }

            public override void Remove(BookNoteDTO item)
            {
                if (item==null)
                {
                    return;
                }
                var note = _baseRepository.FindById(item.Id);
                note.Workbook = null;
                _baseRepository.Edit(note);
                _baseRepository.Save();


            }
        }
    }
}
