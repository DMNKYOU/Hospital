using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PMI.Hospital.Core.Models.People;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence.Models;

namespace PMI.Hospital.Infrastructure.Persistence.ChildrenWardPatients.Repository.Actions.Create
{
    /// <inheritdoc />
    internal class ChildrenWardPatientCreator : IChildrenWardPatientCreator
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext database;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCreator"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="database">The database.</param>
        public ChildrenWardPatientCreator(
            IMapper mapper,
            ApplicationDbContext database)
        { 
            this.mapper = mapper;
            this.database = database;
        }

        /// <inheritdoc />
        public async Task CreateAsync(string patientId, bool active)
        {
            var entityToAdd = new ChildrenWardPatientEntity()
            {
                Id = patientId,
                Active = active,
            };

            await database.ChildrenWardPatients.AddAsync(entityToAdd);
            await database.SaveChangesAsync();
        }
    }
}
