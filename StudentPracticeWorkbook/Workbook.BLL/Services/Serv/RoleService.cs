using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Dapper.Repos;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    public sealed class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _baseRepository;

        public RoleService(IRoleRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
