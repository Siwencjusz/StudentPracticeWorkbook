using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL.Entities;
namespace Workbook.BLL.Services
{
    public interface IAuthorizeServicecs
    {
        bool IsUserCredentialMatched(string login, string password);
        DAL.Entities.User GetAuthorizedUser(Guid Id);
    }
}
