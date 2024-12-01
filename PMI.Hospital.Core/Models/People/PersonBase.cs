using PMI.Hospital.Core.Enums;

namespace PMI.Hospital.Core.Models.People
{
    /// <summary>
    /// The person dto.
    /// </summary>
    public class PersonBase
    {
        /// <summary>
        /// Gets or sets family.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the use value.
        /// </summary>
        public string Use { get; set; }

        /// <summary>
        /// Gets or sets gender status.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets birthday information.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
