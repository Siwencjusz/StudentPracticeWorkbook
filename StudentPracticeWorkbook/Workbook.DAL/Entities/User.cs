using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.DAL.Entities
{
    public class User:EntityBase
    {
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
        public string Email { get; set; }
        public string DetailInformation { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}
