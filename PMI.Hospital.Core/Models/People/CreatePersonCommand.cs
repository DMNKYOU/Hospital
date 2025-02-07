﻿using PMI.Hospital.Core.Enums;

namespace PMI.Hospital.Core.Models.People
{
    /// <summary>
    /// The person create command.
    /// </summary>
    public class CreatePersonCommand : PersonBase
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public string Id { get; set; }
    }
}
