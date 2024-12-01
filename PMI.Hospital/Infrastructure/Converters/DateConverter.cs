using Newtonsoft.Json;

namespace PMI.Hospital.Infrastructure.Converters
{
    public class DateJsonConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();
            
            if (DateTime.TryParse(value, out var parsedDate))
            {
                if (parsedDate > DateTime.Now)
                {
                    throw new JsonSerializationException("BirthDate cannot be in the future.");
                }

                return parsedDate;
            }

            throw new JsonSerializationException($"Invalid date format: {value}");
        }
    }

}