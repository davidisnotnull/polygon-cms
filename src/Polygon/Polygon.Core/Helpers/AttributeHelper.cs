using Polygon.Core.Data.Annotations;
using System;

namespace Polygon.Core.Helpers
{
    public static class AttributeHelper
    {
        public static ContentTypeAttribute GetContentTypeAttribute(Type t)
        {
            return (ContentTypeAttribute) Attribute.GetCustomAttribute(t, typeof(ContentTypeAttribute));
        }
    }
}