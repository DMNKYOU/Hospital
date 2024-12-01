using Newtonsoft.Json;
using PMI.Hospital.Infrastructure.Converters;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PMI.Hospital.Contracts.People
{
    /// <summary>
    /// The person response.
    /// </summary>
    public class PersonResponse
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets family.
        /// </summary>
        [JsonProperty("family")]
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets middle name.
        /// </summary>
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the use value.
        /// </summary>
        [JsonProperty("use")]
        public string Use { get; set; }

        /// <summary>
        /// Gets or sets gender status.
        /// </summary>
        [JsonConverter(typeof(GenderJsonConverter))]
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets birthday information.
        /// </summary>
        [JsonConverter(typeof(DateJsonConverter))]
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
