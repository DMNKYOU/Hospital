using PMI.Hospital.Shared.Enums;
using System;


namespace PMI.Hospital.Infrastructure.Persistence.Models
{
    /// <summary>
    /// The person entity.
    /// </summary>
    public class PersonEntity
    {
        private DateTime birthDate;

        /// <summary>
        /// Gets or sets unique passport id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets family name.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the use value.
        /// </summary>
        public string Use { get; set; }

        /// <summary>
        /// Gets or sets gender status.
        /// </summary>
        public Gender? Gender { get; set; } = Shared.Enums.Gender.Unknown;

        /// <summary>
        /// Gets or sets simulation date.
        /// </summary>
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
        }

        /// <summary>
        /// Gets or sets the children ward patient data of this person.
        /// </summary>
        public ChildrenWardPatientEntity ChildrenWardPatient { get; set; }
    }
}
