using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using ProjectEstimator.DAL.Base.BaseRepository;
using Workbook.BLL.DTOs;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.BLL.Services.Base
{
    public abstract class BaseService<TEntity, Tdto> : IBaseService<TEntity, Tdto> 
        where TEntity : EntityBase
        where Tdto : BaseDTO
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual void Add(Tdto item)
        {
            var x = Mapper.Map<TEntity>(item);
            _baseRepository.Add(x);
            _baseRepository.Save();
        }

        public virtual void Remove(Tdto item)
        {
            TEntity entityToDelete = _baseRepository.FindById(item.Id);
            _baseRepository.Delete(entityToDelete);
            _baseRepository.Save();
        }

        public virtual void Update(Tdto item)
        {
            _baseRepository.Edit(Mapper.Map<TEntity>(item));
            _baseRepository.Save();
        }

        public virtual Tdto FindByID(Guid id)
        {
               return Mapper.Map<Tdto>(_baseRepository.FindById(id));
        }

        public virtual IEnumerable<Tdto>Find(Func<Tdto, bool> predicate)
        {
            List<Tdto> x = Mapper.Map<List<Tdto>>(_baseRepository.GetAll());
            return x.Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<Tdto> FindAll()
        {
            var list = _baseRepository.GetAll();
            return Mapper.Map<List<Tdto>>(list);
        }
    }
}
