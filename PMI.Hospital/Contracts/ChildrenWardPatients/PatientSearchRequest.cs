using Newtonsoft.Json;
using PMI.Hospital.Infrastructure.Converters;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PMI.Hospital.Contracts.ChildrenWardPatients
{
    /// <summary>
    /// The patient search request.
    /// </summary>
    public class PatientSearchRequest
    {
        /// <summary>
        /// Gets or sets date for search.
        /// </summary>
        [Required]
        [StringLength(26,MinimumLength = 2)]
        [RegularExpression(RegularConstants.SearchByDateExpression, ErrorMessage = RegularMessageConstants.SearchDateError)]
        [JsonProperty("searchTerm")]
        public string SearchTerm { get; set; }
    }
}
