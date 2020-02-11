using Microsoft.EntityFrameworkCore;
using Polygon.Core.Data.Context;
using System;

namespace Polygon.Core.UnitTests.Fixtures
{
    public class InMemoryFixture : IDisposable
    {
        public PolygonContext Context => InMemoryContext();

        public void Dispose()
        {
            Context?.Dispose();
        }

        private static PolygonContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PolygonContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            return new PolygonContext(options);
        }
    }
}
