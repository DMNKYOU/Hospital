using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;

namespace PMI.Hospital.Infrastructure.Converters
{
    public class DateJsonConverter : JsonConverter<DateTime>
    {
        private const string FutureDateError = "BirthDate cannot be in the future";
        private readonly string[] _formats =
         {
            "yyyy-MM-ddTHH:mm",
            "yyyy-MM-ddTHH:mm:ss",
            "yyyy-MM-dd",
            "yyyy/MM/ddTHH:mm",
            "yyyy/MM/ddTHH:mm:ss",
            "yyyy/MM/dd",
            "MM/dd/yyyy HH:mm:ss",
            "MM/dd/yyyy HH:mm",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm"
        };

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();

            if (DateTime.TryParseExact(value, _formats, null, System.Globalization.DateTimeStyles.None, out var date))
            { 
                if (date > DateTime.UtcNow.AddMilliseconds(-date.Millisecond))
                {
                    throw new JsonSerializationException(FutureDateError);
                }

                return date;
            }

            throw new JsonSerializationException($"Invalid date format: {value}");
        }
    }

}