using Polygon.Core.Enums.Editor;
using System;

namespace Polygon.Core.Data.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyUiAttribute : Attribute
    {
        private string _displayName;
        private string _description;
        private string _groupName;
        private int? _order;
        private bool? _availableInEditMode;

        public UIType UIType { get; set; }

        // Define the Display Name of the property. This is how the property
        // name appears in the Editor view.
        public virtual string DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        // Define the Description of the property. This appears in the helper
        // text in the editor view.
        public virtual string Description 
        { 
            get => _description; 
            set => _description = value;
        }

        public virtual string GroupName
        {
            get => _groupName; 
            set => _groupName = value;
        }

        public int Order
        {
            get => _order ?? 0;
            set => _order = value;
        }

        public int? GetOrder()
        {
            return _order;
        }

        public bool AvailableInEditMode
        {
            get => !_availableInEditMode.HasValue || _availableInEditMode.Value;
            set => _availableInEditMode = value;
        }

        public bool? GetAvailableInEditMode()
        {
            return _availableInEditMode;
        }
    }
}
