using Newtonsoft.Json;
using PMI.Hospital.Core.Enums;

namespace PMI.Hospital.Infrastructure.Converters
{
    public class GenderJsonConverter : JsonConverter<Gender>
    {
        private const string Error = "Invalid value for Gender";
        public override void WriteJson(JsonWriter writer, Gender value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override Gender ReadJson(JsonReader reader, Type objectType, Gender existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var genderStr = reader.Value?.ToString();
            if (Enum.TryParse<Gender>(genderStr, true, out var gender) && Enum.IsDefined(typeof(Gender), gender))
            {
                return gender;
            }
            throw new JsonSerializationException($"{Error} : {gender}");
        }
    }
}