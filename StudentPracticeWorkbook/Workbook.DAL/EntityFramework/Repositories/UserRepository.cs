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

        public override User Add(User entity)
        {
            entity.Role = null;
            return base.Add(entity);
        }

        public override void Edit(User entity)
        {
            entity.Role = null;
            var x =_dbset.Find(entity.Id);

            base.Edit(entity);
        }
    }
}
