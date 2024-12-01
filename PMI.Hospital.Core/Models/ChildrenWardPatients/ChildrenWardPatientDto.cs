using PMI.Hospital.Core.Enums;

namespace PMI.Hospital.Core.Models.People
{
    /// <summary>
    /// The patient create dto.
    /// </summary>
    public class ChildrenWardPatientDto
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets person data.
        /// </summary>
        public PersonDto Person { get; set; }

        /// <summary>
        /// Gets or sets is active value.
        /// </summary>
        public bool Active { get; set; }
    }
}
