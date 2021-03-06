﻿using Workbook.DAL.Dapper.BaseRepo;
using Workbook.DAL.Dapper.Interfaces;
using Workbook.DAL.Entities;

namespace Workbook.DAL.Dapper.Repos
{
    public sealed class UserRepository :  BaseRepository<User>, IUserRepository
    {
        public UserRepository() : base("Users")
        {
            
        }
    }
}
