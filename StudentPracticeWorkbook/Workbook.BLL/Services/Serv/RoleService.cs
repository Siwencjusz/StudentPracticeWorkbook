using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;

namespace Workbook.BLL.Services.Serv
{
    public sealed class RoleService : BaseService<Workbook.DAL.Entities.Role>, IRoleService
    {
        private readonly IRepository<Workbook.DAL.Entities.Role> _baseRepository;

        public RoleService(IRepository<Workbook.DAL.Entities.Role> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
