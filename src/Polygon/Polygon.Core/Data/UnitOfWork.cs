using Polygon.Core.Data.Entities;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Polygon.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> _repositories;

        public IPolygonContext Context { get; }

        public UnitOfWork(IPolygonContext context)
        {
            _repositories = new Dictionary<Type, object>();
            Context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new GenericRepository<TEntity>(this);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

       
    }
}
