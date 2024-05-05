using System.Text.Json;

namespace AutoMenu.Models.Extensions
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Stores an object in the session.
        /// </summary>
        /// <param name="session">The session in which the object will be stored.</param>
        /// <param name="key">The key associated with the object in the session.</param>
        /// <param name="value">The object to be stored.</param>
        public static void SetObject(this ISession session, string key, object value)
        {
            // Serialize the object to a byte array
            byte[] serializedValue = JsonSerializer.SerializeToUtf8Bytes(value);
            // Store the byte array in the session
            session.Set(key, serializedValue);
        }

        /// <summary>
        /// Retrieves an object from the session.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve.</typeparam>
        /// <param name="session">The session from which the object will be retrieved.</param>
        /// <param name="key">The key associated with the object in the session.</param>
        /// <returns>The object retrieved from the session, or the default value for the type if the key does not exist.</returns>
        public static T? GetObject<T>(this ISession session, string key)
        {
            // If the key is null, return the default value for the type
            if (key == null)
                return default;

            // Try to get the byte array associated with the session key
            byte[]? serializedValue = session.Get(key);
            // If the byte array is null, return the default value for the type
            if (serializedValue == null)
                return default;

            // Deserialize the byte array to the specified type and return the object
            return JsonSerializer.Deserialize<T>(serializedValue);
        }
    }
}
