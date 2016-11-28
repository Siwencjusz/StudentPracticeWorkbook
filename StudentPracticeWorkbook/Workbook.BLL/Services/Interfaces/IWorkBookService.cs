using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Interfaces
{
    public interface IWorkBookService: IBaseService<DAL.Entities.Workbook, WorkbookDTO>
    {
    }
}