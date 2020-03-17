using Polygon.Core.Data.Entities.Blocks;
using System;

namespace Polygon.Core.UnitTests.MockData
{
    internal static class MockBlocks
    {
        internal static TeaserBlock SeedSingleTeaserBlock()
        {
            return new TeaserBlock
            {
                Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"),
                Name = "Test Teaser Block",
                Heading = "Test Teaser Block Heading"
            };
        }

        internal static TeaserBlock[] SeedMultipleTeaserBlocks()
        {
            return new[]
            {
                new TeaserBlock {Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Teaser Block 1", Heading = "Teaser Block 1 Heading"},
                new TeaserBlock {Id = new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"), Name = "Teaser Block 2", Heading = "Teaser Block 2 Heading"},
                new TeaserBlock {Id = new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"), Name = "Teaser Block 3", Heading = "Teaser Block 3 Heading"},
            };
        }
    }
}
