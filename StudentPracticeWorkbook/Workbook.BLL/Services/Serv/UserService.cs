﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.Dapper.Interfaces;
using Workbook.DAL.Dapper.Repos;

namespace User.BLL.Services.Serv
{
    public sealed class UserService : BaseService<Workbook.DAL.Entities.User>, IUserService
    {
        private readonly IRepository<Workbook.DAL.Entities.User> _baseRepository;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public UserService(UserRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public override void Add(Workbook.DAL.Entities.User item)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(
            System.Text.Encoding.UTF32.GetBytes(item.HashPassword)))
            {
                item.HashPassword = md5.ComputeHash(ms).ToString();
            }
            _baseRepository.Add(item);
        }


    }
}
