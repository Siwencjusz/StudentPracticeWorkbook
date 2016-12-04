using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class CompanyDTO : UserDTO
    {
        public string DetailInformation { get; set; }

        public List<WorkbookDTO> ManagedWorkBooks { get; set; }
    }
}
