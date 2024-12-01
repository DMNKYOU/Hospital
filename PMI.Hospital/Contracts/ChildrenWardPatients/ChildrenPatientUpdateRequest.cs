using Newtonsoft.Json;
using PMI.Hospital.Infrastructure.Converters;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PMI.Hospital.Contracts.ChildrenWardPatients
{
    /// <summary>
    /// The patient create request.
    /// </summary>
    public class ChildrenPatientUpdateRequest : ChildrenPatientRequest
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
