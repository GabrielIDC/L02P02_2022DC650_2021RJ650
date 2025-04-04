using Microsoft.AspNetCore.Http;
using System.Text.Json;
namespace L02P02_2022DC650_2021RJ650.Helpers
{
    public static class SessionExtensions
    {
        public static void SetDecimal(this ISession session, string key, decimal value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static decimal? GetDecimal(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? (decimal?)null : JsonSerializer.Deserialize<decimal>(value);
        }

    }
}
