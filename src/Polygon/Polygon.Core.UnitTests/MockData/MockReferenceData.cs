using System;
using Polygon.Core.Data.Entities.ReferenceData;

namespace Polygon.Core.UnitTests.MockData
{
    internal static class MockReferenceData
    {
        public static ReferenceType[] SeedMultipleReferenceTypes()
        {
            return new[]
            {
                new ReferenceType { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Stars", Description = "A list of all the stars of the firmament"},
                new ReferenceType { Id = new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"), Name = "Planets", Description = "So many shiny planets going around the sun"},
                new ReferenceType { Id = new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"), Name = "Moons", Description = "That's no moon"}
            };
        }

        public static ReferenceType SeedSingleReferenceType()
        {
            return new ReferenceType
            {
                Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"),
                Name = "Test Reference Type",
                Description = "Lorem ipsum dolor sit amet adipiscing"
            };
        }

        public static ReferenceObject[] SeedReferenceObjects(ReferenceType referenceType)
        {
            return new[]
            {
                new ReferenceObject { Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"), Name = "Jupiter", ReferenceType = referenceType},
                new ReferenceObject { Id = new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"), Name = "Saturn", ReferenceType = referenceType},
                new ReferenceObject { Id = new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"), Name = "Mars", ReferenceType = referenceType}
            };
        }

        public static ReferenceObject SeedSingleReferenceObject(ReferenceType referenceType)
        {
            return new ReferenceObject
            {
                Id = new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"),
                Name = "Test Reference Object",
                ReferenceType = referenceType
            };
        }
    }
}
