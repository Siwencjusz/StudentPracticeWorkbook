using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.DAL.Entities
{
    public class Student : User
    {
        public string LastName { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public Guid? DepartmentId { get; set; }

        public virtual List<Workbook> OwnWorkBooks { get; set; }

        public  bool IsStudentGetJob { get; set; }
    }
}
