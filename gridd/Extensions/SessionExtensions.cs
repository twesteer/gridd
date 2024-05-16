using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace gridd.Extensions
{
    public static class SessionExtensions
    {
        // Метод для сохранения объекта в сессии
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Метод для получения объекта из сессии
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
