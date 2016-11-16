using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.DAL.Entities
{
    public class User:EntityBase
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string HashPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public string DetailInformation { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public Guid? DepartmentId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public Guid? RoleId { get; set; }
        public virtual List<WorkBook> WorkBooks { get; set; }
    }
}
