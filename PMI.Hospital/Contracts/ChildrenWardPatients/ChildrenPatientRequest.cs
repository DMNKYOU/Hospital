using Newtonsoft.Json;
using PMI.Hospital.Infrastructure.Converters;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PMI.Hospital.Contracts.ChildrenWardPatients
{
    /// <summary>
    /// The patient base request.
    /// </summary>
    public class ChildrenPatientRequest
    {
        /// <summary>
        /// Gets or sets the use value.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
