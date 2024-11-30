using System.ComponentModel;

namespace PMI.Hospital.Shared.Enums

{
    /// <summary>
    /// The execution status.
    /// </summary>
    [DefaultValue(Unknown)]
    public enum Gender
    {
        /// <summary>
        /// The male gender.
        /// </summary>
        Male,

        /// <summary>
        /// The female gender.
        /// </summary>
        Female,

        /// <summary>
        /// The other gender.
        /// </summary>
        Other,

        /// <summary>
        /// The unknown gender.
        /// </summary>
        Unknown,
    }
}
