using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class BookNoteDTO : BaseDTO
    {
        public string Note { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public WorkbookDTO Workbook { get; set; }
    }
}
