using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;

namespace PMI.Service.PersonalizationHub.Infrastructure.Persistence.MSSQL.EntityTypeConfigurations
{
    /// <inheritdoc/>
    internal class ChildrenWardPatientEntityTypeConfiguration : IEntityTypeConfiguration<ChildrenWardPatientEntity>
    {
        private const string TableName = "ChildrenWardPatients";

        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<ChildrenWardPatientEntity> builder)
        {
            builder
                .ToTable(TableName, ApplicationDbContext.DefaultSchemaName)
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Active);
        }
    }
}
