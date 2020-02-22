using System.Collections.Generic;

namespace Polygon.Core.Models.Navigation
{
    public class MenuBuilder
    {
        public MenuBuilder()
        {
            MenuItems = new List<MenuItem>();
        }

        public MenuBuilder(List<MenuItem> menuItems)
        {
            MenuItems = menuItems;
        }
        
        public List<MenuItem> MenuItems { get; set; }
    }
}
