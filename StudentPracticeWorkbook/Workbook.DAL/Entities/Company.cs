using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.DAL.Entities
{
    public class Company : User
    {
        public string DetailInformation { get; set; }

        
        public virtual List<Workbook> ManagedWorkBooks { get; set; }
    }
}
