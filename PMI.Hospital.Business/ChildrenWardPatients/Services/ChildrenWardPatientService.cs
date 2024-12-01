using Ardalis.Specification;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PMI.Hospital.Business.Specifications;
using PMI.Hospital.Business.Specifications.Search;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Infrastructure.Persistence.People.Repository;
using PMI.Hospital.Shared.Constants;
using PMI.Hospital.Shared.Exceptions;
using PMI.Hospital.Shared.Helpers;
using System.ComponentModel.Design;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PMI.Hospital.Business.ChildrenWardPatients.Services
{
    /// <inheritdoc />
    public class ChildrenWardPatientService : IChildrenWardPatientService
    {
        private const string DateFormatError = "Invalid date format in query:";
        private const string FirstMonthDateFormat = "-01";
        private const int OnlyYearLenght = 4;
        private const int YearAndMonthLenght = 7;
        private const int DateLenght = 10;
        private const int FullDate = 16;

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

        public async Task<List<ChildrenWardPatientDto>> ListEntitiesByDate(string searchTerm)
        {
            var (prefix, startDate, endDate) = ParseDateQuery(searchTerm);
            
            Specification<PersonEntity> specification;
           
            switch (prefix)
            {
                case OperatorConstants.Equal:
                    specification = new EqualDateSearchInfoSpec(startDate, endDate);
                    break;

                case OperatorConstants.NotEqual:
                    specification = new NotEqualDateSearchInfoSpec(startDate, endDate);
                    break;

                case OperatorConstants.LessThan:
                case OperatorConstants.EndsBefore:
                    specification = new LessDateSearchInfoSpec(startDate);
                    break;

                case OperatorConstants.LessOrEqual:
                    specification = new LessOrEqualDateSearchInfoSpec(endDate);                    
                    break;

                case OperatorConstants.GreaterOrEqual:
                    specification = new GreaterOrEqualDateSearchInfoSpec(startDate);
                    break;

                case OperatorConstants.GreaterThan:
                case OperatorConstants.StartsAfter:
                    specification = new StartsAfterDateSearchInfoSpec(endDate);
                    break;

                default:
                    specification = new ApproximatelyDateSearchInfoSpec(startDate, endDate);
                    break;
            }

            return this.mapper.Map<List<ChildrenWardPatientDto>>(await personEntityRepository.Fetcher.ListAsync(specification));
        }

        private (string prefix, DateTime startDate, DateTime endDate) ParseDateQuery(string query)
        {
            var prefix = query[..2];

            var datePart = query[2..].Trim();

            DateTime startDate;
            DateTime endDate;

            if (datePart.Length == OnlyYearLenght && int.TryParse(datePart, out var year))
            {
                startDate = new DateTime(year, 1, 1, 0, 0, 0);
                endDate = new DateTime(year, 12, 31, 23, 59, 59);
            }
            else if (datePart.Length == YearAndMonthLenght && DateTime.TryParse(datePart + FirstMonthDateFormat, out var monthDate))
            {
                startDate = new DateTime(monthDate.Year, monthDate.Month, 1, 0, 0, 0);
                endDate = startDate.AddMonths(1).AddSeconds(-1);
            }
            else if (datePart.Length == DateLenght && DateTime.TryParse(datePart, out var fullDate))
            {
                startDate = new DateTime(fullDate.Year, fullDate.Month, fullDate.Day, 0, 0, 0);
                endDate = startDate.AddDays(1).AddSeconds(-1); 
            }
            else if (datePart.Length >= FullDate && DateTime.TryParse(datePart, out var dateTime))
            {
                startDate = dateTime;
                endDate = dateTime;
            }
            else
            {
                throw new ArgumentException($"{DateFormatError} {datePart}");
            }

            return (prefix, startDate, endDate);
        }

    }
}
