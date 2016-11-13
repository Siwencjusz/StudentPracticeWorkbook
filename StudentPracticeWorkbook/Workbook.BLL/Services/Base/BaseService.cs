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
        public void Add(T item)
        {
            _baseRepository.Add(item);
        }

        public void Remove(T item)
        {
            _baseRepository.Remove(item);
        }

        public void Update(T item)
        {
            _baseRepository.Update(item);
        }

        public T FindByID(Guid id)
        {
            return _baseRepository.FindByID(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _baseRepository.Find(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return _baseRepository.FindAll();
        }
    }
}
