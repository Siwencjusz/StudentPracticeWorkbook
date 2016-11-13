using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.DAL.Entities
{
    public class Department:EntityBase
    {
        [Required]
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
