using Polygon.Core.Data.Entities.Pages;
using System;

namespace Polygon.Core.UnitTests.MockData
{
    internal static class MockPages
    {
        internal static StandardPage SeedSinglePage()
        {
            return new StandardPage
            {
                Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"),
                Name = "Test Standard Page",
                Heading = "Standard Page Unit Test Heading"
            };
        }

        internal static StandardPage[] SeedMultipleStandardPages()
        {
            return new[]
            {
                new StandardPage { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Test Page 1", Heading = "Test Page 1 Heading"},
                new StandardPage { Id = new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"), Name = "Test Page 2", Heading = "Test Page 2 Heading"},
                new StandardPage { Id = new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"), Name = "Test Page 3", Heading = "Test Page 3 Heading"}
            };
        }
    }
}
