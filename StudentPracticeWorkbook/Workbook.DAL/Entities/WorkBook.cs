using System.Collections.Generic;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.DAL.Entities
{
    public class WorkBook:EntityBase
    {
        public string DocumentUrl { get; set; }
        public virtual User Comapny { get; set; }
        public virtual User Employee { get; set; }
        public virtual User Student { get; set; }
        public virtual Department Department { get; set; }
        public List<BookNote> Noteses { get; set; }
    }
}