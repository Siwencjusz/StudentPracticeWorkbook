using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEstimator.DAL.Base;
using ProjectEstimator.DAL.Base.BaseRepository;
using ProjectEstimator.DAL.Entities.Roles;
using Workbook.DAL;
using Workbook.DAL.Entities;

namespace ProjectEstimator.DAL.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(StudentWorkBookContext context) : base(context)
        {
        }
    }
}