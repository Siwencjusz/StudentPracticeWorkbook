using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;

namespace Workbook.BLL.Services.Interfaces
{
    public interface IUserService: IBaseService<DAL.Entities.User, UserDTO>
    {
    }
}