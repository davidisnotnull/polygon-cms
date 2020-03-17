using System;
using Polygon.Core.Data.Entities.Taxonomy;

namespace Polygon.Core.UnitTests.MockData
{
    public static class MockTaxonomyData
    {
        public static Category[] SeedMultipleCategories()
        {
            return new[]
            {
                new Category { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Test Category 01", Description = "Description for Test Category 01"},
                new Category { Id = new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"), Name = "Test Category 02", Description = "Description for Test Category 02"},
                new Category { Id = new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"), Name = "Test Category 03", Description = "Description for Test Category 03"},
                new Category { Id = new Guid("d1284314-8964-4814-8d30-02c30dca767a"), Name = "Test Category 04", Description = "Description for Test Category 04"}
            };
        }

        public static Category SeedSingleCategory()
        {
            return new Category { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"),  Name = "Test Category 01", Description = "Description for Test Category 01" };
        }

        public static Tag[] SeedMultipleTags()
        {
            return new[]
            {
                new Tag { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Tag 01"},
                new Tag { Id = new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"), Name = "Tag 02"},
                new Tag { Id = new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"), Name = "Tag 03"},
                new Tag { Id = new Guid("d1284314-8964-4814-8d30-02c30dca767a"), Name = "Tag 04"},
                new Tag { Id = new Guid("f83112fd-5cf2-435e-8c21-c088ed13b73a"), Name = "Tag 05"}
            };
        }

        public static Tag SeedSingleTag()
        {
            return new Tag { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Tag 01" };
        }
    }
}
