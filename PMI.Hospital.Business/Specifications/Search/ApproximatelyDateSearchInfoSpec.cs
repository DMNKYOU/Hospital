using Ardalis.Specification;
using PMI.Hospital.Infrastructure.Persistence.Models;
using System.Linq;

namespace PMI.Hospital.Business.Specifications.Search
{
    /// <summary>
    /// The approximately specification.
    /// </summary>
    public class ApproximatelyDateSearchInfoSpec : Specification<PersonEntity>
    {
        private const int WeekNumberDays = 7;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualDateSearchInfoSpec"/> class.
        /// </summary>
        /// <param name="startDate">The start search date.</param>
        /// <param name="endDate">The end search date.</param>
        /// <param name="asNoTracking">The flag to indicate whether query is need to be tracked or not.</param>
        public ApproximatelyDateSearchInfoSpec(DateTime startDate, DateTime endDate, bool asNoTracking = true)
        {
            var range = TimeSpan.FromDays(WeekNumberDays);
            Query
                .Include(x => x.ChildrenWardPatient)
                .Where(p => p.ChildrenWardPatient != null && (p.BirthDate >= startDate - range && p.BirthDate <= endDate + range));

            if (asNoTracking)
            {
                Query.AsNoTracking();
            }
        }
    }
}
