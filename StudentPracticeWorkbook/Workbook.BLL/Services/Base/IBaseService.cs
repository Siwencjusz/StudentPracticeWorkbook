using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Workbook.BLL.DTOs;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.BLL.Services.Base
{
    public interface IBaseService<TEntity, Tdto> 
        where TEntity : EntityBase
        where Tdto : BaseDTO
    {
        void Add(Tdto item);
        void Remove(Tdto item);
        void Update(Tdto item);
        Tdto FindByID(Guid id);
        IEnumerable<Tdto> Find(Func<Tdto, bool> predicate);
        IEnumerable<Tdto> FindAll();
    }
}