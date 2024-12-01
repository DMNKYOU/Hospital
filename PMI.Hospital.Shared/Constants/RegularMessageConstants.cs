using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace PMI.Hospital.Shared.Constants
{
    /// <summary>
    /// Provides collection constants.
    /// </summary>
    public static class RegularMessageConstants
    {
        /// <summary>
        /// The only letters message.
        /// </summary>
        public const string OnlyLettersError = "The value should contain only letters";

        /// <summary>
        /// The only letters message.
        /// </summary>
        public const string SearchDateError = "The date should follow format type + date like ap2013-03-14";
    }
}
