using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Workbook.DAL.Entities.baseEntity;

namespace Workbook.BLL.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        private readonly IRepository<T> _baseRepository;

        public BaseService(IRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual void Add(T item)
        {
            _baseRepository.Add(item);
        }

        public virtual void Remove(T item)
        {
            _baseRepository.Remove(item);
        }

        public virtual void Update(T item)
        {
            _baseRepository.Update(item);
        }

        public virtual T FindByID(Guid id)
        {
            return _baseRepository.FindByID(id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _baseRepository.Find(predicate);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _baseRepository.FindAll();
        }
    }
}
