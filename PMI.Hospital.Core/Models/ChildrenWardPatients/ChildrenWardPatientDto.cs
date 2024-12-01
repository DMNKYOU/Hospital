using PMI.Hospital.Core.Enums;

namespace PMI.Hospital.Core.Models.People
{
    /// <summary>
    /// The patient create dto.
    /// </summary>
    public class ChildrenWardPatientDto : ChildrenWardPatientBaseDto
    {
        /// <summary>
        /// Gets or sets person data.
        /// </summary>
        public PersonDto Person { get; set; }
    }
}
