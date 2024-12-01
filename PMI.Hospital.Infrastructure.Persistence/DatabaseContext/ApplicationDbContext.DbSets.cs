using Microsoft.EntityFrameworkCore;
using PMI.Hospital.Infrastructure.Persistence.Models;

namespace PMI.Hospital.Infrastructure.Persistence.DatabaseContext
{
    /// <summary>
    /// Provides access for <see cref="DbSet{TEntity}"/> in this context.
    /// </summary>
    public partial class ApplicationDbContext
    {
        /// <summary>
        /// Gets or sets <see cref="DbSet{TEntity}"/> for <see cref="ApplicationDbContext"/>.
        /// </summary>
        public DbSet<PersonEntity> People { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DbSet{TEntity}"/> for <see cref="ApplicationDbContext"/>.
        /// </summary>
        public DbSet<ChildrenWardPatientEntity> ChildrenWardPatients { get; set; }
    }
}
