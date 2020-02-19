using Polygon.Core.Resources;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Polygon.Core.Extensions
{
    public static class EnumExtension
    {

        public static string GetName(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(ErrorMessages.EnumNullReference);

            return Enum.GetName(value.GetType(), value);
        }

        public static int GetValue(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(ErrorMessages.EnumNullReference);

            return (int) value.GetTypeCode();
        }

        public static string GetDescription(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(ErrorMessages.EnumNullReference);

            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }

        public static string GetDisplayName(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(ErrorMessages.EnumNullReference);

            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) 
                return string.Empty;
            
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}
