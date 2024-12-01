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
    public class ChildrenPatientCreateRequest : ChildrenPatientRequest
    {
        /// <summary>
        /// Gets or sets person id.
        /// </summary>
        [JsonProperty("personId")]
        public string PersonId { get; set; }
    }
}
