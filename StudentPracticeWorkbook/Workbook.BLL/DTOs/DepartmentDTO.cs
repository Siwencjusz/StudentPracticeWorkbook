using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class DepartmentDTO : BaseDTO
    {
        public string Name { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}
