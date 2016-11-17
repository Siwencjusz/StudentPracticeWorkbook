﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL;
using Workbook.DAL.Dapper.Repos;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    namespace Workbook.BLL.Services.Serv
    {
        public sealed class BookNoteService : BaseService<BookNote>, IBookNoteService
        {
            private readonly IBookNoteRepository _baseRepository;

            public BookNoteService(IBookNoteRepository baseRepository) : base(baseRepository)
            {
                _baseRepository = baseRepository;
            }
        }
    }
}
