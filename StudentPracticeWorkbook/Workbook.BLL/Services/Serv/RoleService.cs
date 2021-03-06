﻿using ProjectEstimator.DAL.Entities.Roles;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;

namespace Workbook.BLL.Services.Serv
{
    public sealed class RoleService : BaseService<Role, RoleDTO>, IRoleService
    {
        private readonly IRoleRepository _baseRepository;

        public RoleService(IRoleRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
