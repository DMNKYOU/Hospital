using PMI.Hospital.Core.Models.People;

namespace PMI.Hospital.Business.ChildrenWardPatients.Services
{
    /// <summary>
    /// Provides interface for patients.
    /// </summary>
    public interface IChildrenWardPatientService
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="personId">The person id data.</param>
        /// <param name="active">The is active value.</param>
        Task Create(string personId, bool active);

        /// <summary>
        /// Gets patinet data.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>result of async operation.</returns>
        Task<ChildrenWardPatientDto> Get(string id);

        /// <summary>
        /// Changes state value.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>result of async operation.</returns>
        Task<ChildrenWardPatientDto> ChangeActiveState(string id, bool newActiveValue);

        /// <summary>
        /// Removes entity.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>result of async operation.</returns>
        Task Remove(string id);

        /// <summary>
        /// List entities by date term.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>result of async operation.</returns>
        Task<List<ChildrenWardPatientDto>> ListEntitiesByDate(string searchTerm);
    }
}
