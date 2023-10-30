using System;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using System.Linq.Expressions;

namespace RepositoryLayer.Repository
{
    public class RepositoryModified<T> : IRepositoryModified<T> where T : BaseEntityModified
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;

        public RepositoryModified(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _applicationDbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _applicationDbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            if (predicate is null)
                return query.AsEnumerable();
            else
                return query.Where(predicate).AsEnumerable();

            //return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifiedDate = DateTime.Now;
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }
        public void InsertBulk(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.AddRange(entity);
            _applicationDbContext.SaveChanges();
        }

    }
}
