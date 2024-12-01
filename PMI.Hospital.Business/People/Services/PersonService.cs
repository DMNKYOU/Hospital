using AutoMapper;
using Microsoft.Extensions.Logging;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.People.Repository;
using PMI.Hospital.Shared.Exceptions;
using PMI.Hospital.Shared.Helpers;

namespace PMI.Hospital.Business.People.Services
{
    /// <summary>
    /// Provides interface for people.
    /// </summary>
     public class PersonService : IPersonService
    {
        private readonly IMapper mapper;
        private ILogger<PersonService> logger;
        private IPersonRepository personEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The mapper.</param>
        /// <param name="personEntityRepository">The person entity repository.</param>
        public PersonService(
            IMapper mapper,
            ILogger<PersonService> logger,
            IPersonRepository personEntityRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.personEntityRepository = personEntityRepository;
        }

        /// <inheritdoc />
        public async Task<PersonDto> Get(string id)
        { 
            var entity = await personEntityRepository.Fetcher.GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(PersonDto));
            }

            return entity;
        }
        /// <inheritdoc />
        public async Task<PersonDto> Create(CreatePersonCommand command)
        {
            var entity =this.mapper.Map<PersonDto>(command);
            entity.Id = EntityHelper.GetNewSystemName();
            await personEntityRepository.Creator.CreateAsync(entity);

            return entity;
        }

        /// <inheritdoc />
        public async Task Remove(string id)
        {
            await personEntityRepository.Remover.RemoveAsync(id);
        }
    }
}
