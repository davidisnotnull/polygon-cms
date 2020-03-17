using System;
using System.Collections.Generic;

namespace Polygon.Core.UnitTests.Helpers
{
    public static class GuidSequenceHelper
    {
        private static readonly IList<Guid> _guidSequence = new[]
        {
            new Guid("41195988-ebd2-4cb7-a72a-7a6584f03867"),
            new Guid("375f1b96-ecd7-45e3-84ec-8830cd05273e"),
            new Guid("1d5cce6c-4192-4828-ad7e-04bdd441bb7f"),
            new Guid("d1284314-8964-4814-8d30-02c30dca767a"),
            new Guid("f83112fd-5cf2-435e-8c21-c088ed13b73a")
        };

        public static Guid GetGuid(int id)
        {
            return _guidSequence[id];
        }
    }
}
