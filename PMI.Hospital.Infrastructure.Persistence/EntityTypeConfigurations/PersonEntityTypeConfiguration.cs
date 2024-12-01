using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMI.Hospital.Infrastructure.Persistence.Models;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;

namespace PMI.Service.PersonalizationHub.Infrastructure.Persistence.MSSQL.EntityTypeConfigurations
{
    /// <inheritdoc/>
    internal class PersonEntityTypeConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        private const string TableName = "People";

        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder
                .ToTable(TableName, ApplicationDbContext.DefaultSchemaName)
                .HasKey(x => x.Id);

            builder
               .Property(x => x.BirthDate)
               .IsRequired();

            builder
                .HasIndex(p => p.BirthDate);

            builder
               .Property(x => x.Family)
               .IsRequired();

            builder
                .HasOne(x => x.ChildrenWardPatient)
                .WithOne(x => x.Person)
                .HasForeignKey<ChildrenWardPatientEntity>(x => x.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
