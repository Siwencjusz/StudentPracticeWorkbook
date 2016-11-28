using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Login { get; set; }

        public string HashPassword { get; set; }

        public string Email { get; set; }

        public RoleDTO Role { get; set; }

        public string FullName => Name;

    }
}
