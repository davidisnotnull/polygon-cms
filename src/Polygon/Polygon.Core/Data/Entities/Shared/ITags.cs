using Polygon.Core.Data.Entities.Taxonomy;
using System.Collections.Generic;

namespace Polygon.Core.Data.Entities.Shared
{
    public interface ITags
    {
        public IEnumerable<Tag> Tags { get; set; }
    }
}
