using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace PMI.Hospital.Shared.Exceptions
{
    /// <summary>
    /// The entity not found exception.
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        private const string ErrorMessagePattern = "{0} is not found.";

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="entityName">The entity name.</param>
        public EntityNotFoundException(string entityName)
            : base(string.Format(ErrorMessagePattern, entityName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        [ExcludeFromCodeCoverage]
        protected EntityNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
