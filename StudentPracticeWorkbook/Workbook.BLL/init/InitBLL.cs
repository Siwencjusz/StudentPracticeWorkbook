using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Workbook.BLL.DTOs;
using Workbook.DAL.Entities;

namespace Workbook.BLL.init
{
    public static class InitBLL
    {
        public static void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
            });
        }
    }
}
