using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Shared.Exceptions;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Remove
{
    /// <inheritdoc />
    internal class ChildrenWardPatientRemover : IChildrenWardPatientRemover
    {
        private readonly ApplicationDbContext database;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrenWardPatientRemover"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public ChildrenWardPatientRemover(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <inheritdoc />
        public async Task RemoveAsync(string id)
        {
            var entityToDelete = await this.database.ChildrenWardPatients
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entityToDelete is null)
            {
                throw new EntityNotFoundException(nameof(ChildrenWardPatientEntity));
            }

            this.database.Remove(entityToDelete);
            await this.database.SaveChangesAsync();
        }
    }
}
