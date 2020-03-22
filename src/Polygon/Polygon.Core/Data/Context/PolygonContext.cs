using Microsoft.EntityFrameworkCore;
using Polygon.Core.Data.Entities.Blocks;
using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Entities.Taxonomy;
using Polygon.Core.Data.Interfaces;

namespace Polygon.Core.Data.Context
{
    public class PolygonContext : DbContext, IPolygonContext
    {
        public PolygonContext(DbContextOptions options):
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferenceObject>()
                .HasOne(r => r.ReferenceType)
                .WithMany(t => t.ReferenceObjects)
                .HasForeignKey(r => r.ReferenceTypeId);
        }

        public DbSet<ReferenceType> ReferenceTypes { get; set; }
        public DbSet<ReferenceObject> ReferenceObjects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<HomePage> HomePage { get; set; }
        public DbSet<StandardPage> StandardPages { get; set; }
        public DbSet<TeaserBlock> TeaserBlocks { get; set; }

    }
}
