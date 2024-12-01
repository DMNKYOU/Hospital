using System.ComponentModel;
using System.Runtime.Serialization;

namespace PMI.Hospital.Core.Enums

{
    /// <summary>
    /// The execution status.
    /// </summary>
    [DefaultValue(Unknown)]
    [Serializable]
    public enum Gender
    {
        /// <summary>
        /// The male gender.
        /// </summary>
        [EnumMember(Value = "male")]
        [Description("Male")]
        Male,

        /// <summary>
        /// The female gender.
        /// </summary>
        [EnumMember(Value = "female")]
        [Description("Female")]
        Female,

        /// <summary>
        /// The other gender.
        /// </summary>
        [EnumMember(Value = "other")]
        [Description("Other")]
        Other,

        /// <summary>
        /// The unknown gender.
        /// </summary>
        [EnumMember(Value = "unknown")]
        [Description("Unknown")]
        Unknown,
    }
}
