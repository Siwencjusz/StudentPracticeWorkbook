using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.DAL.Entities
{
    public class WorkBook:EntityBase
    {
        public string DocumentUrl { get; set; }

        [ForeignKey("CompanyId")]
        public virtual User Company { get; set; }

        public Guid? CompanyId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual User Employee { get; set; }

        public Guid? EmployeeId { get; set; }

        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        public Guid? StudentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public Guid? DepartmentId { get; set; }

        public virtual List<BookNote> Noteses { get; set; }

        public int? GradeCompany { get; set; }

        public int? GradeDepartment { get; set; }
    }
}