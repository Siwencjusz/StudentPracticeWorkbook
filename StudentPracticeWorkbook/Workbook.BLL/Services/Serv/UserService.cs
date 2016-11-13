using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;

namespace User.BLL.Services.Serv
{
    public sealed class UserService: BaseService<Workbook.DAL.Entities.User>,IUserService
    {
        private readonly IRepository<Workbook.DAL.Entities.User> _baseRepository;

        public UserService(IRepository<Workbook.DAL.Entities.User> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        
    }
}
