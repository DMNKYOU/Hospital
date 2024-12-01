using PMI.Hospital.Core.Models.People;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Fetch
{
    /// <summary>
    /// The fetcher.
    /// </summary>
    public interface IPersonFetcher
    {
        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        Task<PersonDto> GetByIdAsync(string id);
    }
}
