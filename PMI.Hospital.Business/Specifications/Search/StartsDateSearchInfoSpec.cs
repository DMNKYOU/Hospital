using Ardalis.Specification;
using PMI.Hospital.Infrastructure.Persistence.Models;
using System.Linq;

namespace PMI.Hospital.Business.Specifications.Search
{
    /// <summary>
    /// The starts after specification.
    /// </summary>
    public class StartsAfterDateSearchInfoSpec : Specification<PersonEntity>
    {
        private const int WeekNumberDays = 7;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualDateSearchInfoSpec"/> class.
        /// </summary>
        /// <param name="date">The search date.</param>
        /// <param name="asNoTracking">The flag to indicate whether query is need to be tracked or not.</param>
        public StartsAfterDateSearchInfoSpec(DateTime date, bool asNoTracking = true)
        {
            Query
                .Include(x => x.ChildrenWardPatient)
                .Where(p => p.ChildrenWardPatient != null && p.BirthDate > date);

            if (asNoTracking)
            {
                Query.AsNoTracking();
            }
        }
    }
}
