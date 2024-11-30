﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;

#nullable disable

namespace PMI.Hospital.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("hospital")
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PMI.Hospital.Infrastructure.Persistence.Models.ChildrenWardPatientEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ChildrenWardPatients", "hospital");
                });

            modelBuilder.Entity("PMI.Hospital.Infrastructure.Persistence.Models.PersonEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Use")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BirthDate");

                    b.ToTable("People", "hospital");
                });

            modelBuilder.Entity("PMI.Hospital.Infrastructure.Persistence.Models.ChildrenWardPatientEntity", b =>
                {
                    b.HasOne("PMI.Hospital.Infrastructure.Persistence.Models.PersonEntity", "Person")
                        .WithOne("ChildrenWardPatient")
                        .HasForeignKey("PMI.Hospital.Infrastructure.Persistence.Models.ChildrenWardPatientEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PMI.Hospital.Infrastructure.Persistence.Models.PersonEntity", b =>
                {
                    b.Navigation("ChildrenWardPatient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
