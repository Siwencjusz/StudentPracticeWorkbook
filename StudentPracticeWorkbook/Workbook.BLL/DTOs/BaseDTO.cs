using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbook.BLL.DTOs
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(BaseDTO))
            {
                BaseDTO objDTO = (BaseDTO)obj;

                return objDTO.Id == Id;
            }
            return false;
        }
    }
}
