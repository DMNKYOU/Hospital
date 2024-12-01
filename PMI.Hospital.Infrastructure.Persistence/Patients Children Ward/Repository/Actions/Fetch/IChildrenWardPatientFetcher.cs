using Ardalis.Specification;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.Models;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Fetch
{
    /// <summary>
    /// The fetcher.
    /// </summary>
    public interface IChildrenWardPatientFetcher
    {
        /// <summary>
        /// Gets dto async.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ChildrenWardPatientDto> GetAsync(ISpecification<ChildrenWardPatientEntity> specification);

        /// <summary>
        /// Indicates the entity by id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The async operation result.</returns>
        Task<bool> ExistsAsync(string id);
    }
}
