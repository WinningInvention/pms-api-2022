using System;
using DomainLayer.Models;
using System.Linq.Expressions;

namespace RepositoryLayer.Interfaces
{
    public interface IRepositoryModified<T> where T : BaseEntityModified
    {
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        void InsertBulk(List<T> entity);
    }
}
