using System;

namespace Polygon.Core.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPolygonContext Context { get; }

        void Commit();
    }
}
