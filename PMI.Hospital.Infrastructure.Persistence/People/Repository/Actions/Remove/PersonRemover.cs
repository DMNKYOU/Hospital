using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Shared.Exceptions;

namespace PMI.Hospital.Infrastructure.Persistence.People.Repository.Actions.Remove
{
    /// <inheritdoc />
    internal class PersonRemover : IPersonRemover
    {
        private readonly ApplicationDbContext database;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRemover"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public PersonRemover(ApplicationDbContext database)
        {
            this.database = database;
        }

        /// <inheritdoc />
        public async Task RemoveAsync(string id)
        {
            var entityToDelete = await this.database.People
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entityToDelete is null)
            {
                throw new EntityNotFoundException(nameof(PersonEntity));
            }

            this.database.Remove(entityToDelete);
            await this.database.SaveChangesAsync();
        }
    }
}
