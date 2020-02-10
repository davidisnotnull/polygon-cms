using Polygon.Core.Data.Entities;
using Polygon.Core.Data.Interfaces.Repositories;
using System;

namespace Polygon.Core.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPolygonContext Context { get; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        int Commit();
    }
}
