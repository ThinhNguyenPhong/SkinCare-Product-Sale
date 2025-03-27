using Newtonsoft.Json;

namespace SkinCare_Product_Sale.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var jsonData = JsonConvert.SerializeObject(value, settings);
            session.SetString(key, jsonData);
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var jsonData = session.GetString(key);
            return jsonData == null ? default(T) : JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
