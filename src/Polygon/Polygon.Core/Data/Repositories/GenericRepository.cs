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

        public virtual T GetById(Guid id)
        {
            return _unitOfWork.Context.Set<T>().Find(id);
        }

        public virtual T GetAvailableById(Guid id)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault(x => x.IsDeleted == false && x.Id == id);
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

        public virtual T Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _unitOfWork.Context.Set<T>().Add(entity);

            return entity;
        }

        public virtual IEnumerable<T> Add(IEnumerable<T> entities)
        {
            var baseEntities = entities as T[] ?? entities.ToArray();
            foreach (var entity in baseEntities)
            {
                Add(entity);
            }

            return baseEntities;
        }

        public virtual T Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _unitOfWork.Context.Set<T>().Remove(entity);
        }

        public virtual void Delete(Guid id)
        {
            Delete(GetById(id));
        }

        public virtual void SoftDelete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.IsDeleted = true;
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        public virtual void SoftDelete (Guid id)
        {
            SoftDelete(GetById(id));
        }

    }
}