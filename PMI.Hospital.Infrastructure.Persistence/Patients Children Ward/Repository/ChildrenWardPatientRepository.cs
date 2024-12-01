using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Remove;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Update;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository
{
    /// <inheritdoc/>
    public class ChildrenWardPatientRepository : IChildrenWardPatientRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenWardPatientRepository"/> class.
        /// </summary>
        /// <param name="fetcher">The fetcher.</param>
        /// <param name="creator">The creator.</param>
        /// <param name="remover">The remover.</param>
        public ChildrenWardPatientRepository(
            IChildrenWardPatientFetcher fetcher,
            IChildrenWardPatientUpdater updater,
            IChildrenWardPatientCreator creator,
            IChildrenWardPatientRemover remover)
        {
            Fetcher = fetcher;
            Creator = creator;
            Remover = remover;
            Updater = updater;
        }

        /// <inheritdoc />
        public IChildrenWardPatientFetcher Fetcher { get; }

        /// <inheritdoc />
        public IChildrenWardPatientCreator Creator { get; }

        /// <inheritdoc />
        public IChildrenWardPatientUpdater Updater { get; }

        /// <inheritdoc />
        public IChildrenWardPatientRemover Remover { get; }
    }
}
