using PMI.Hospital.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PMI.Hospital.Infrastructure.Persistence.Models
{
    /// <summary>
    /// The patient entity.
    /// </summary>
    public class ChildrenWardPatientEntity
    {
        //private DateTime birthDate; /////can be aadded as a variant

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the is active value.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the personal info.
        /// </summary>
        public PersonEntity Person { get; set; }
    }
}
