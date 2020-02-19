using System;

namespace Polygon.Core.Extensions
{
    public static class StringExtension
    {
        public static string GetUntilCharacterOrEmpty(this string text, string stopAt = ".")
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            
            var charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

            return charLocation > 0 ? text.Substring(0, charLocation) : string.Empty;
        }
    }
}
