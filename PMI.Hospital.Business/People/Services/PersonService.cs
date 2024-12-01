using AutoMapper;
using Microsoft.Extensions.Logging;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.People.Repository;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Shared.Exceptions;
using PMI.Hospital.Shared.Helpers;
using System.ComponentModel.Design;

namespace PMI.Hospital.Business.People.Services
{
    /// <inheritdoc />
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
            var exists = await personEntityRepository.Fetcher.ExistsAsync(command.Id);
            
            if (exists)
            {
                throw new InvalidDataException(HelperConstants.ExistsError);
            }

            var entity =this.mapper.Map<PersonDto>(command);
            entity.Id ??= EntityHelper.GetNewSystemName();
            await personEntityRepository.Creator.CreateAsync(entity);

            return entity;
        }

        /// <inheritdoc />
        public Task Remove(string id)
        {
            return personEntityRepository.Remover.RemoveAsync(id);
        }
    }
}
