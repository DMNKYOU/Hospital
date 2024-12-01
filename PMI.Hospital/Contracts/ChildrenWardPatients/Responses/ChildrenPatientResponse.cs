using Newtonsoft.Json;
using PMI.Hospital.Infrastructure.Converters;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PMI.Hospital.Contracts.ChildrenWardPatients.Responses
{
    /// <summary>
    /// The patient response.
    /// </summary>
    public class ChildrenPatientResponse
    {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required]
        [JsonProperty("name")]
        public PatientDataResponse Name { get; set; }

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

        /// <summary>
        /// Gets or sets the active value.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
