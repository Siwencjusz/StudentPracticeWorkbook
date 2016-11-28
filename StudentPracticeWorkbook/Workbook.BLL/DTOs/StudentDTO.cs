using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class StudentDTO : UserDTO
    {
        public string LastName { get; set; }

        public DepartmentDTO Department { get; set; }

        public List<WorkbookDTO> OwnWorkBooks { get; set; }

        public string FullName => Name + " " + LastName;
    }
}
