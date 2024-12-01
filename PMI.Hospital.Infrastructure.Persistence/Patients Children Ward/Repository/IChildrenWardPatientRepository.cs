using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Remove;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Update;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository
{
    /// <summary>
    /// The children ward patient entity repository.
    /// </summary>
    public interface IChildrenWardPatientRepository
    {
        /// <summary>
        /// The patient entity fetcher.
        /// </summary>
        IChildrenWardPatientFetcher Fetcher { get; }

        /// <summary>
        /// The entity updater.
        /// </summary>
        IChildrenWardPatientUpdater Updater { get; }

        /// <summary>
        /// The patient entity setter.
        /// </summary>
        IChildrenWardPatientCreator Creator { get; }

        /// <summary>
        /// The patient entity remover.
        /// </summary>
        IChildrenWardPatientRemover Remover { get; }
    }
}
