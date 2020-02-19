using Polygon.Core.Data.Entities.Pages;

namespace Polygon.Core.UnitTests.MockData
{
    internal static class MockPages
    {
        internal static StandardPage SeedSinglePage()
        {
            return new StandardPage
            {
                Name = "Test Standard Page",
                Heading = "Standard Page Unit Test Heading"
            };
        }

        internal static StandardPage[] SeedMultipleStandardPages()
        {
            return new[]
            {
                new StandardPage { Name = "Test Page 1", Heading = "Test Page 1 Heading"},
                new StandardPage { Name = "Test Page 2", Heading = "Test Page 2 Heading"},
                new StandardPage { Name = "Test Page 3", Heading = "Test Page 3 Heading"}
            };
        }
    }
}
