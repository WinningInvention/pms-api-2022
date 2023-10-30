using System;
using System.Linq.Expressions;
using DomainLayer.Models;

namespace RepositoryLayer.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();

    }
}

