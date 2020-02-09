using Polygon.Core.Data.Interfaces;

namespace Polygon.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPolygonContext Context { get; }

        public UnitOfWork(IPolygonContext context)
        {
            Context = context;
        }   

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
