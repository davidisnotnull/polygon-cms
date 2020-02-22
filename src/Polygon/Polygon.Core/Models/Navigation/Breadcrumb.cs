using System.Collections.Generic;

namespace Polygon.Core.Models.Navigation
{
    public class Breadcrumb
    {
        public Breadcrumb()
        {
            Trail = new List<MenuItem>();
        }

        public Breadcrumb(List<MenuItem> menuItems)
        {
            Trail = menuItems;
        }

        public List<MenuItem> Trail { get; }
        
        public int Crumbs ()
        {
            return Trail.Count;
        }
    }
}
