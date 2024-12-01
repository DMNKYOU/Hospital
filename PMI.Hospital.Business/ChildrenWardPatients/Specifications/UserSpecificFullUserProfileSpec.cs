using Ardalis.Specification;
using PMI.Hospital.Infrastructure.Persistence.Models;

namespace PMI.Hospital.Business.ChildrenWardPatients.Services
{
    /// <summary>
    /// The patient profile specification.
    /// </summary>
    public class FullChildWardPatientSpec : Specification<ChildrenWardPatientEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullChildWardPatientSpec"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="asNoTracking">The flag to indicate whether query is need to be tracked or not.</param>
        public FullChildWardPatientSpec(string id, bool asNoTracking)
        {
            this.Query
                .Include(x => x.Person)
                .Where(x => x.Id == id);

            if (asNoTracking)
            {
                this.Query.AsNoTracking();
            }
        }
    }
}
