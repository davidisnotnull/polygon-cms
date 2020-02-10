using Microsoft.EntityFrameworkCore;
using Polygon.Core.Data.Entities;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Polygon.Core.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T :  BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual T GetById(int id)
        {
            return _unitOfWork.Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetAvailable()
        {
            return _unitOfWork.Context.Set<T>().Where(e => e.IsDeleted == false).AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> whereClause)
        {
            return _unitOfWork.Context.Set<T>().Where(whereClause).AsEnumerable();
        }

        public bool Exists(Expression<Func<T, bool>> whereClause)
        {
            return _unitOfWork.Context.Set<T>().Any(whereClause);
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            T existing = _unitOfWork.Context.Set<T>().Find(entity);

            if (existing != null)
                _unitOfWork.Context.Set<T>().Remove(existing);
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void SoftDelete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.IsDeleted = true;
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        public virtual void SoftDelete (int id)
        {
            SoftDelete(GetById(id));
        }

    }
}