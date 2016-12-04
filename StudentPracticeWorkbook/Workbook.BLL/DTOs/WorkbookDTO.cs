using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class WorkbookDTO : BaseDTO
    {
        public string DocumentUrl { get; set; }

        public UserDTO Company { get; set; }

        public UserDTO Employee { get; set; }

        public UserDTO Student { get; set; }

        public DepartmentDTO Department { get; set; }

        public List<BookNoteDTO> Noteses { get; set; }

        public int? GradeCompany { get; set; }

        public int? GradeDepartment { get; set; }
    }
}
