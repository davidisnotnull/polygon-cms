using Polygon.Core.Data.Entities.Taxonomy;
using System.Collections.Generic;

namespace Polygon.Core.Data.Entities.Shared
{
    public interface ICategories
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
