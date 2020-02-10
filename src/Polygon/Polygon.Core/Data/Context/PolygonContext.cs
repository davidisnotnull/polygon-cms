using Microsoft.EntityFrameworkCore;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Interfaces;

namespace Polygon.Core.Data.Context
{
    public class PolygonContext : DbContext, IPolygonContext
    {
        public PolygonContext(DbContextOptions<PolygonContext> options):
            base(options)
        {

        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message, ex);
            }
        }

        public DbSet<ReferenceType> ReferenceTypes { get; set; }
        public DbSet<ReferenceObject> ReferenceObjects { get; set; }


    }
}
