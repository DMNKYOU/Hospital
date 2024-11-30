namespace PMI.Hospital.Shared.Extensions
{
    /// <summary>
    /// Provides methods to calculate pages.
    /// </summary>
    public static class PagesCalculationExtensions
    {
        /// <summary>
        /// Calculates total pages.
        /// </summary>
        /// <param name="totalItems">The total items.</param>
        /// <param name="pageSize">The page size.</param>
        public static int CalculateTotalPagesCount(int totalItems, int pageSize)
        {
            return (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}

