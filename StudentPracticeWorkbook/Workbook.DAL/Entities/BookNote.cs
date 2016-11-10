using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.DAL.Entities
{
    public class BookNote:EntityBase
    {
        public string Note { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public virtual WorkBook WorkBook { get; set; }
    }
}
