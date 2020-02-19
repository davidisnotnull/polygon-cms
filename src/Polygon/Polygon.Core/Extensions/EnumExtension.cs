using Polygon.Core.Resources;
using System;
using System.ComponentModel;
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
    }
}
