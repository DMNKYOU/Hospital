using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Shared.Constants;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Update
{
    /// <inheritdoc/>
    internal class ChildrenWardPatientUpdater : IChildrenWardPatientUpdater
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext database;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenWardPatientUpdater"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="database">The database.</param>
        public ChildrenWardPatientUpdater(
            IMapper mapper,
            ApplicationDbContext database)
        {
            this.mapper = mapper;
            this.database = database;
        }

        /// <inheritdoc />
        public async Task<ChildrenWardPatientDto> ChangeActiveState(string id, bool newActiveValue)
        {
            var entity = await this.database.ChildrenWardPatients
                .Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);

            entity!.Active = newActiveValue;
            var result = this.database.Update(entity);
            await this.database.SaveChangesAsync();

            return this.mapper.Map<ChildrenWardPatientDto>(result.Entity);
        }
    }
}
