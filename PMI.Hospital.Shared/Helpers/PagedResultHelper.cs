using System;

namespace PMI.Hospital.Shared.Helpers
{
    /// <summary>
    /// Provides helper for paged result.
    /// </summary>
    public static class PagedResultHelper
    {
        /// <summary>
        /// Calculate total pages.
        /// </summary>
        /// <param name="totalItems">The total items.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>
        /// Total pages count.
        /// </returns>
        public static int CalculateTotalPages(int totalItems, int pageSize)
        {
            return (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
