using PMI.Hospital.Core.Enums;

namespace PMI.Hospital.Core.Models.People
{
    /// <summary>
    /// The person extended dto.
    /// </summary>
    public class PersonExtendedDto : PersonDto
    {
        ///// <summary>
        ///// Gets or sets patient data.
        ///// </summary>
        //public ChildrenWardPatientBaseDto Patient { get; set; }

        /// <summary>
        /// Gets or sets is active value.
        /// </summary>
        public bool PatientActiveState { get; set; }
    }
}
