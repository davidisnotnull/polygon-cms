using Polygon.Core.Data.Annotations;
using Polygon.Core.Data.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace Polygon.Core.Helpers
{
    public static class ContentHelper
    {
        public static Type GetTypeByGuid(string guid)
        {
            var assembly = Assembly.GetAssembly(typeof(BaseEntity));
            var types = from type in assembly.GetTypes()
                where Attribute.IsDefined(type, typeof(ContentTypeAttribute))
                select type;

            foreach (var type in types)
            {
                var contentTypeAttribute = AttributeHelper.GetContentTypeAttribute(type);
                if (contentTypeAttribute.Guid == guid)
                    return type;
            }

            return null;
        }

        public static object ConvertTypeToClass(Type contentType)
        {
            if (!contentType.IsClass) 
                return null;
            
            var instance = Activator.CreateInstance(contentType);
            return instance;
        }
    }
}
