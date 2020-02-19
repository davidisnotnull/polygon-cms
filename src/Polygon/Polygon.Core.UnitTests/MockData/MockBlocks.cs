using Polygon.Core.Data.Entities.Blocks;

namespace Polygon.Core.UnitTests.MockData
{
    internal static class MockBlocks
    {
        internal static TeaserBlock SeedSingleTeaserBlock()
        {
            return new TeaserBlock
            {
                Name = "Test Teaser Block",
                Heading = "Test Teaser Block Heading"
            };
        }

        internal static TeaserBlock[] SeedMultipleTeaserBlocks()
        {
            return new[]
            {
                new TeaserBlock {Name = "Teaser Block 1", Heading = "Teaser Block 1 Heading"},
                new TeaserBlock {Name = "Teaser Block 2", Heading = "Teaser Block 2 Heading"},
                new TeaserBlock {Name = "Teaser Block 3", Heading = "Teaser Block 3 Heading"},
            };
        }
    }
}
