
using PMI.Hospital.Core.Models.People;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Update
{
    /// <summary>
    /// The data request configuration updater.
    /// </summary>
    public interface IChildrenWardPatientUpdater
    {
        /// <summary>
        /// Changes active state.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="newActiveValue">The active new value.</param>
        /// <returns>The result of asynchronous operation.</returns>
        Task<ChildrenWardPatientDto> ChangeActiveState(string id, bool newActiveValue);
    }
}
