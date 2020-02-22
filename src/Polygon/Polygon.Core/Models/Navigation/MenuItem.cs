namespace Polygon.Core.Models.Navigation
{
    public class MenuItem
    {
        public MenuItem()
        {
            IsDisabled = false;
        }

        public string Name { get; set; }

        public string Area { get; set; }

        public string Link { get; set; }

        public string Target { get; set; }

        public bool IsDisabled { get; set; }
    }
}
