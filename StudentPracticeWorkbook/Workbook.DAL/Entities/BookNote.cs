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
    public class BookNote:EntityBase
    {
        public string Note { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        [Required,ForeignKey("WorkBookId")]
        public virtual Workbook Workbook { get; set; }

        public Guid WorkBookId { get; set; }
    }
}
