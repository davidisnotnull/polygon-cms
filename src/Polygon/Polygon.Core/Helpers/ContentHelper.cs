using Polygon.Core.Data.Annotations;
using Polygon.Core.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

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

        public static IEnumerable<T> GetEnumerableOfTypes<T>(params object[] constructorArgs)
            where T : class, IComparable<T>
        {
            var objects = new List<T>();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            objects.Sort();
            return objects;
        }
    }
}
