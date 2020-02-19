using System.Collections.Generic;
using System.Linq;

namespace Polygon.Core.Models
{
    public class SelectionFactory
    {
        public List<KeyValuePair<int, string>> SelectionItems;

        public SelectionFactory(IEnumerable<KeyValuePair<int, string>> selectionItems, bool orderAscending = false)
        {
            SelectionItems = orderAscending ? selectionItems.OrderBy(x => x.Value).ToList() : selectionItems.ToList();
        }
    }
}
