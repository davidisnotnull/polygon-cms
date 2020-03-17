using System;

namespace Polygon.Core.Data.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ContentTypeAttribute : Attribute
    {
        private Guid? _guid;
        private int? _order;
        private bool? _availableInEditMode;

        /// <summary>
        /// Gets or sets the unique id for the corresponding ContentType
        /// </summary>
        public string Guid
        {
            get => _guid?.ToString();
            set
            {
                switch (value)
                {
                    case "":
                        _guid = System.Guid.Empty;
                        break;
                    default:
                        if (!System.Guid.TryParse(value, out var result))
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        _guid = result;
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Guid? GetGuid()
        {
            return _guid;
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

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }
    }
}
