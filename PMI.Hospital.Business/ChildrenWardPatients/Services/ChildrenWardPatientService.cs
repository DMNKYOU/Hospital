using AutoMapper;
using Microsoft.Extensions.Logging;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository;
using PMI.Hospital.Infrastructure.Persistence.People.Repository;
using PMI.Hospital.Shared.Exceptions;
using PMI.Hospital.Shared.Helpers;
using System.ComponentModel.Design;

namespace PMI.Hospital.Business.ChildrenWardPatients.Services
{
    /// <inheritdoc />
    public class ChildrenWardPatientService : IChildrenWardPatientService
    {
        private readonly IMapper mapper;
        private ILogger<ChildrenWardPatientService> logger;
        private IPersonRepository personEntityRepository;
        private IChildrenWardPatientRepository childrenWardPatientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenWardPatientService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The mapper.</param>
        /// <param name="personEntityRepository">The person entity repository.</param>
        /// <param name="childrenWardPatientRepository">The patients entity repository.</param>
        public ChildrenWardPatientService(
            IMapper mapper,
            ILogger<ChildrenWardPatientService> logger,
            IPersonRepository personEntityRepository,
            IChildrenWardPatientRepository childrenWardPatientRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.personEntityRepository = personEntityRepository;
            this.childrenWardPatientRepository = childrenWardPatientRepository;
        }

        /// <inheritdoc />
        public async Task<ChildrenWardPatientDto> Get(string id)
        {
            var specificationFullData = new FullChildWardPatientSpec(id, asNoTracking: true);
            var entity = await childrenWardPatientRepository.Fetcher.GetAsync(specificationFullData);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(ChildrenWardPatientDto));
            }

            return entity;
        }

        /// <inheritdoc />
        public async Task<ChildrenWardPatientDto> ChangeActiveState(string id, bool newActiveValue)
        {
            var isValidData = await childrenWardPatientRepository.Fetcher.ExistsAsync(id);

            if (!isValidData)
            {
                throw new InvalidOperationException();
            }

            return await childrenWardPatientRepository.Updater.ChangeActiveState(id, newActiveValue);
        }

        /// <inheritdoc />
        public async Task Create(string id, bool active)
        {
            var isValidPersonData =  await personEntityRepository.Fetcher.ExistsAsync(id);

            if (!isValidPersonData)
            {
                throw new InvalidOperationException();
            }

            await childrenWardPatientRepository.Creator.CreateAsync(id, active);
        }

        /// <inheritdoc />
        public async Task Remove(string id)
        {
            await childrenWardPatientRepository.Remover.RemoveAsync(id);
        }
    }
}
