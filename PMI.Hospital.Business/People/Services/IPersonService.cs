using PMI.Hospital.Core.Models.People;

namespace PMI.Hospital.Business.People.Services
{
    /// <summary>
    /// Provides interface for work with people.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="command">The create command.</param>
        /// <returns>Created entity.</returns>
        Task<PersonDto> Create(CreatePersonCommand command);

        /// <summary>
        /// Gets person data.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>result of async operation.</returns>
        Task<PersonDto> Get(string id);

        /// <summary>
        /// Remove person.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>result of async operation.</returns>
        Task Remove(string id);
    }
}
