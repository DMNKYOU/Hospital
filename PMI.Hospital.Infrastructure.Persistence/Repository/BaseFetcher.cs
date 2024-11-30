using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Shared.Common;
using PMI.Hospital.Shared.Contracts;
using PMI.Hospital.Shared.Extensions;
namespace PMI.Hospital.Infrastructure.Persistence.Repository
{
    /// <summary>
    /// The base fetcher providing base functionality to fetch entities.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TDto">The data transfer object type.</typeparam>
    internal abstract class BaseFetcher<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IMapper mapper;
        protected const int DefaultPageNumber = 1;
        protected const int DefaultPageSize = 1;

        /// <summary>
        /// The database provider.
        /// </summary>
        protected readonly ApplicationDbContext database;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFetcher{TEntity, TDto}"/> class.
        /// </summary>
        /// <param name="database">The database provider.</param>
        /// <param name="mapper">The mapper.</param>
        protected BaseFetcher(ApplicationDbContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets entities async.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TEntity>> ListEntitiesAsync(
            ISpecification<TEntity> specification)
        {
            return await GetQuerySpecification(specification).ToListAsync();
        }

        /// <summary>
        /// Gets dto's async.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IEnumerable<TDto>> ListAsync(
            ISpecification<TEntity> specification)
        {
            var entities = await GetQuerySpecification(specification).ToListAsync();

            return mapper.Map<IEnumerable<TDto>>(entities);
        }

        /// <summary>
        /// Gets dto's async.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="request">The paged request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<PageResult<TDto>> ListPagedAsync(
            ISpecification<TEntity> specification, PagedRequest request)
        {
            var pageNumber = request.PageNumber ?? DefaultPageNumber;
            var pageSize = request.PageSize ?? DefaultPageSize;

            var baseQuery = GetQuerySpecification(specification);

            var entities = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            var total = baseQuery
                .Count();

            var totalPages = PagesCalculationExtensions.CalculateTotalPagesCount(total, pageSize);

            return new PageResult<TDto>(
                mapper.Map<ICollection<TDto>>(entities),
                pageNumber,
                totalPages,
                total,
                entities.Count);
        }

        /// <summary>
        /// Gets dto async.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<TDto> GetAsync(
            ISpecification<TEntity> specification)
        {
            var entity = await GetQuerySpecification(specification).FirstOrDefaultAsync();

            return mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Gets entity async.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TEntity> GetEntityAsync(ISpecification<TEntity> specification)
        {
            return GetQuerySpecification(specification).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the query by specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>Instance of <see cref="IQueryable{TEntity}"/> type based on the specification.</returns>
        protected IQueryable<TEntity> GetQuerySpecification(ISpecification<TEntity> specification)
        {
            return SpecificationEvaluator.Default.GetQuery(database.Set<TEntity>().AsQueryable(), specification);
        }
    }
}
