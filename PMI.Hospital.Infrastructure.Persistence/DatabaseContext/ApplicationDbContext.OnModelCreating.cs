using System;
using Microsoft.EntityFrameworkCore;
using PMI.Service.PersonalizationHub.Infrastructure.Persistence.MSSQL.EntityTypeConfigurations;

namespace PMI.Hospital.Infrastructure.Persistence.DatabaseContext
{
    /// <summary>
    /// Provides realizations for <see cref="DbContext.OnModelCreating"/>.
    /// </summary>
    public partial class ApplicationDbContext
    {
        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DefaultSchemaName);
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChildrenWardPatientEntityTypeConfiguration());
        }
    }
}
