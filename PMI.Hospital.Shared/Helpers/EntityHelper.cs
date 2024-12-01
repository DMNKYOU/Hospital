namespace PMI.Hospital.Shared.Helpers
{
    /// <summary>
    /// Provides helper for entity.
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// The default postfix number when it isn't needed.
        /// </summary>
        public const int DefaultNotUsePostfixNumber = 0;

        /// <summary>
        /// Generates new system name.
        /// </summary>
        /// <returns>System name.</returns>
        public static string GetNewSystemName()
        {
            return Guid.NewGuid().ToString("D").Replace('-', '_');
        }
    }
}
