using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Remove;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository
{
    /// <summary>
    /// The person entity repository.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// The person entity fetcher.
        /// </summary>
        IPersonFetcher Fetcher { get; }

        ///// <summary>
        ///// The person entity updater.
        ///// </summary>
        //IPersonUpdater Updater { get; }

        /// <summary>
        /// The person entity setter.
        /// </summary>
        IPersonCreator Creator { get; }

        /// <summary>
        /// The person entity remover.
        /// </summary>
        IPersonRemover Remover { get; }
    }
}
