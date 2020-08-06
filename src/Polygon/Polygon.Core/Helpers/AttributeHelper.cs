using Polygon.Core.Data.Annotations;
using System;
using System.Reflection;

namespace Polygon.Core.Helpers
{
    public static class AttributeHelper
    {
        public static ContentTypeAttribute GetContentTypeAttribute(Type t)
        {
            return (ContentTypeAttribute) Attribute.GetCustomAttribute(t, typeof(ContentTypeAttribute));
        }

        public static PropertyUiAttribute GetPropertyUiAttribute(PropertyInfo prop)
        {
            return (PropertyUiAttribute) Attribute.GetCustomAttribute(prop, typeof(PropertyUiAttribute));
        }
    }
}