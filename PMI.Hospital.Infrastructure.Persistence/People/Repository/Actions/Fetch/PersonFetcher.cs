using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Infrastructure.Persistence.Repository;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Fetch
{
    /// <inheritdoc />
    internal class PersonFetcher : BaseFetcher<PersonEntity, PersonDto>, IPersonFetcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonFetcher"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="database">The database.</param>
        public PersonFetcher(
            IMapper mapper,
            ApplicationDbContext database)
            : base(database, mapper)
        {
        }

        public async Task<PersonDto> GetByIdAsync(string id)
        {
            var entity = await database.People
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<PersonDto>(entity);
        }
    }
}
