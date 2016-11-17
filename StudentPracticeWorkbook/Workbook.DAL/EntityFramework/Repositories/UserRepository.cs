using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEstimator.DAL.Base.BaseRepository;
using Workbook.DAL.Entities;

namespace Workbook.DAL.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StudentWorkBookContext context) : base(context)
        {
        }
    }
}
