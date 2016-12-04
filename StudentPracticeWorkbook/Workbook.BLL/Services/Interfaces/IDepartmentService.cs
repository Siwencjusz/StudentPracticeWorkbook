using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    public interface IDepartmentService : IBaseService<Department, DepartmentDTO>
    {
    }
}