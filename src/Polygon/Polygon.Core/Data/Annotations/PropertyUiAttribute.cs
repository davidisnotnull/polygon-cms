using Polygon.Core.Enums.Editor;
using System;

namespace Polygon.Core.Data.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PropertyUiAttribute : Attribute
    {
        private int? _order;

        public UIType UIType { get; set; }

        // Define the Display Name of the property. This is how the property
        // name appears in the Editor view.
        public string DisplayName { get; set; }

        // Define the Description of the property. This appears in the helper
        // text in the editor view.
        public string Description { get; set; }

        public string Placeholder { get; set; }

        public string GroupName { get; set; }

        public int Order
        {
            get => _order ?? 0;
            set => _order = value;
        }

        public int? GetOrder()
        {
            return _order;
        }
    }
}
