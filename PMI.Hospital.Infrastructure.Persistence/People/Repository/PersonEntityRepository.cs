using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Remove;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository
{
    /// <inheritdoc/>
    public class PersonEntityRepository : IPersonEntityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonEntityRepository"/> class.
        /// </summary>
        /// <param name="fetcher">The fetcher.</param>
        /// <param name="updater">The updater.</param>
        /// <param name="creator">The creator.</param>
        /// <param name="remover">The remover.</param>
        public PersonEntityRepository(
            IPersonFetcher fetcher,
            //IPersonUpdater updater,
            IPersonCreator creator,
            IPersonRemover remover)
        {
            //Fetcher = fetcher;
            //Updater = updater;
            //Setter = setter;
            Remover = remover;
        }

        /// <inheritdoc />
        public IPersonFetcher Fetcher { get; }

        ///// <inheritdoc />
        //public IPersonUpdater Updater { get; }

        /// <inheritdoc />
        public IPersonCreator Creator { get; }

        /// <inheritdoc />
        public IPersonRemover Remover { get; }
    }
}
