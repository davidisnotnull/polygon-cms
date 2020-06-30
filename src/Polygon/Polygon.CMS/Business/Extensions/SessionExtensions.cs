using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Polygon.CMS.Business.Extensions
{
    /// <summary>
    /// This class extends the HttpContext.Session to add a Get and a Set method
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Use this to deserialize an object that's been stored in a Session Cookie
        /// </summary>
        /// <typeparam name="T">Type of object that we want to return</typeparam>
        /// <param name="session">Current HttpContext Session</param>
        /// <param name="key">Required session cookie key</param>
        /// <returns>An object of type T</returns>
        /// <remarks>
        /// You can call this method as follows, using the HttpContext:
        /// <![CDATA[var recordedTime = HttpContext.Session.Get<DateTime>(SessionKeyTime);]]>
        /// </remarks>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        /// <summary>
        /// Use this to serialize an object into the HttpContext Session
        /// </summary>
        /// <typeparam name="T">Object to Set</typeparam>
        /// <param name="session">Current HttpContext Session</param>
        /// <param name="key">Required session cookie key</param>
        /// <param name="value">Value of the object to set</param>
        /// <remarks>
        /// You can call this method as follows, using the HttpContext:
        /// <![CDATA[HttpContext.Session.Set<DateTime>(SessionKeyTime, recordedTime);]]>
        /// </remarks>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
    }
}
