using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Infrastructure.Persistence.Repository;
using PMI.Hospital.Shared.Constants;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Fetch
{
    /// <inheritdoc />
    internal class ChildrenWardPatientFetcher : BaseFetcher<ChildrenWardPatientEntity, ChildrenWardPatientDto>, IChildrenWardPatientFetcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenWardPatientFetcher"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="database">The database.</param>
        public ChildrenWardPatientFetcher(
            IMapper mapper,
            ApplicationDbContext database)
            : base(database, mapper)
        {
        }

        /// <inheritdoc />
        public async Task<bool> ExistsAsync(string id)
        {
            return await database.ChildrenWardPatients.CountAsync(x => x.Id == id) == HelperConstants.OneItem;
        }
    }
}
