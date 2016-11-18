using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workbook.DAL;
using Workbook.DAL.Entities.baseEntity;

namespace ProjectEstimator.DAL.Base.BaseRepository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        // ReSharper disable once InconsistentNaming
        protected StudentWorkBookContext _entities;

        // ReSharper disable once InconsistentNaming
        protected readonly IDbSet<T> _dbset;


        // ReSharper disable once PublicConstructorInAbstractClass
        public BaseRepository(StudentWorkBookContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }


        public virtual IEnumerable<T> GetAll()
        {
            return _dbset;
        }

        public virtual IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }


        public virtual T Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public virtual T FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }


        public T FindById(Guid id)
        {
            return _dbset.Find(id);
        }
    }
}
