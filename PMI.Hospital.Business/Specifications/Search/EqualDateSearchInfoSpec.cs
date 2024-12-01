using Ardalis.Specification;
using PMI.Hospital.Infrastructure.Persistence.Models;
using System.Linq;

namespace PMI.Hospital.Business.Specifications.Search
{
    /// <summary>
    /// The equal specification.
    /// </summary>
    public class EqualDateSearchInfoSpec : Specification<PersonEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EqualDateSearchInfoSpec"/> class.
        /// </summary>
        /// <param name="startDate">The start search date.</param>
        /// <param name="endDate">The end search date.</param>
        /// <param name="asNoTracking">The flag to indicate whether query is need to be tracked or not.</param>
        public EqualDateSearchInfoSpec(DateTime startDate, DateTime endDate, bool asNoTracking = true)
        {
            Query
                .Include(x => x.ChildrenWardPatient)
                .Where(p => p.ChildrenWardPatient != null && (p.BirthDate >= startDate && p.BirthDate <= endDate));

            if (asNoTracking)
            {
                Query.AsNoTracking();
            }
        }
    }
}
