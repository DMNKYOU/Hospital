using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Create;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Fetch;
using PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Remove;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository
{
    /// <inheritdoc/>
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="fetcher">The fetcher.</param>
        /// <param name="creator">The creator.</param>
        /// <param name="remover">The remover.</param>
        public PersonRepository(
            IPersonFetcher fetcher,
            IPersonCreator creator,
            IPersonRemover remover)
        {
            Fetcher = fetcher;
            Creator = creator;
            Remover = remover;
        }

        /// <inheritdoc />
        public IPersonFetcher Fetcher { get; }

        /// <inheritdoc />
        public IPersonCreator Creator { get; }

        /// <inheritdoc />
        public IPersonRemover Remover { get; }
    }
}
