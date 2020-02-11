using Polygon.Core.Data.Entities.ReferenceData;

namespace Polygon.Core.UnitTests.MockData
{
    internal static class MockReferenceData
    {
        public static ReferenceType[] SeedMultipleReferenceTypes()
        {
            return new[]
            {
                new ReferenceType { Name = "Stars", Description = "A list of all the stars of the firmament"},
                new ReferenceType { Name = "Planets", Description = "So many shiny planets going around the sun"},
                new ReferenceType { Name = "Moons", Description = "That's no moon"}
            };
        }

        public static ReferenceType SeedSingleReferenceType()
        {
            return new ReferenceType
            {
                Name = "Test Reference Type",
                Description = "Lorem ipsum dolor sit amet adipiscing"
            };
        }

        public static ReferenceObject[] SeedReferenceObjects(ReferenceType referenceType)
        {
            return new[]
            {
                new ReferenceObject { Name = "Jupiter", ReferenceType = referenceType},
                new ReferenceObject { Name = "Saturn", ReferenceType = referenceType},
                new ReferenceObject { Name = "Mars", ReferenceType = referenceType}
            };
        }

        public static ReferenceObject SeedSingleReferenceObject(ReferenceType referenceType)
        {
            return new ReferenceObject
            {
                Name = "Test Reference Object",
                ReferenceType = referenceType
            };
        }
    }
}
