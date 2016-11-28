using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class EmployeeDTO : UserDTO
    {
        public string LastName { get; set; }

        public DepartmentDTO Department { get; set; }

        public List<WorkbookDTO> ManagedWorkBooks { get; set; }

        public string FullName => Name + " " + LastName;
    }
}
