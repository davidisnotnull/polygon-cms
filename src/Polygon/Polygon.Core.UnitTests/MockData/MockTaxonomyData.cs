using Polygon.Core.Data.Entities.Taxonomy;

namespace Polygon.Core.UnitTests.MockData
{
    public static class MockTaxonomyData
    {
        public static Category[] SeedMultipleCategories()
        {
            return new[]
            {
                new Category { Name = "Test Category 01", Description = "Description for Test Category 01"},
                new Category { Name = "Test Category 02", Description = "Description for Test Category 02"},
                new Category { Name = "Test Category 03", Description = "Description for Test Category 03"},
                new Category { Name = "Test Category 04", Description = "Description for Test Category 04"}
            };
        }

        public static Category SeedSingleCategory()
        {
            return new Category { Name = "Test Category 01", Description = "Description for Test Category 01" };
        }

        public static Tag[] SeedMultipleTags()
        {
            return new[]
            {
                new Tag { Name = "Tag 01"},
                new Tag { Name = "Tag 02"},
                new Tag { Name = "Tag 03"},
                new Tag { Name = "Tag 04"},
                new Tag { Name = "Tag 05"}
            };
        }

        public static Tag SeedSingleTag()
        {
            return new Tag { Name = "Tag 01" };
        }
    }
}
