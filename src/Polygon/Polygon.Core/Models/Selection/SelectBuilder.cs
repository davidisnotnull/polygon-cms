using System.Collections.Generic;
using System.Linq;

namespace Polygon.Core.Models.Selection
{
    public class SelectBuilder
    {
        public List<SelectionItem> Items;

        public SelectBuilder()
        {
            Items = new List<SelectionItem>();
        }

        public SelectBuilder(IEnumerable<KeyValuePair<int, string>> selectionItems, bool orderAscending = false)
        {
            Items = new List<SelectionItem>();
            
            var keyValuePairs = selectionItems.ToList();
            
            foreach (var (key, value) in keyValuePairs)
            {
                Items.Add(new SelectionItem
                {
                    Id = key,
                    Value = value
                });
            }

            if (orderAscending)
                OrderByAscending();
        }

        public void AddItemToSelectList(int id, string value)
        {
            Items.Add(new SelectionItem
            {
                Id = id,
                Value = value
            });
        }

        public void OrderByAscending()
        {
            var orderedList = Items.OrderBy(x => x.Value).ToList();
            Items = orderedList;
        }
    }
}
