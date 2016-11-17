using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjectEstimator.DAL.Base.BaseRepository;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.BLL.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual void Add(T item)
        {
            _baseRepository.Add(item);
        }

        public virtual void Remove(T item)
        {
            _baseRepository.Delete(item);
        }

        public virtual void Update(T item)
        {
            _baseRepository.Edit(item);
        }

        public virtual T FindByID(Guid id)
        {
            return _baseRepository.FindById(id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _baseRepository.GetBy(predicate);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
