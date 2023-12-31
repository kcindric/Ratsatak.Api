﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ratsatak.Infrastructure.Persistence.DbContexts;

#nullable disable

namespace Ratsatak.Infrastructure.Migrations
{
    [DbContext(typeof(RatsatakDbContext))]
    partial class RatsatakDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ratsatak.Domain.Departments.Department", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OfficeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Department", "Department");
                });

            modelBuilder.Entity("Ratsatak.Domain.LandRegistryUnits.LandRegistryUnit", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool?>("Condominiums")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<string>("LandRegistryUnitNumber")
                        .HasColumnType("text");

                    b.Property<int?>("MainBookId")
                        .HasColumnType("integer");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("Verificated")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("LandRegistryUnit", "LandRegistryUnit");
                });

            modelBuilder.Entity("Ratsatak.Domain.Municipalities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RegNum")
                        .HasColumnType("integer");

                    b.Property<bool>("Scraped")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Municipality", "Municipality");
                });

            modelBuilder.Entity("Ratsatak.Domain.Offices.Office", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Office", "Office");
                });

            modelBuilder.Entity("Ratsatak.Domain.Parcels.Entities.ParcelPart", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<bool?>("Building")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastChangeLogNumber")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ParcelId")
                        .HasColumnType("integer");

                    b.Property<int>("PossessionSheetId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParcelId");

                    b.HasIndex("PossessionSheetId");

                    b.ToTable("ParcelPart", "Parcel");
                });

            modelBuilder.Entity("Ratsatak.Domain.Parcels.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<int?>("BuildingRemark")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DetailSheetNumber")
                        .HasColumnType("text");

                    b.Property<string>("Geometry")
                        .HasColumnType("text");

                    b.Property<bool?>("HasBuildingRight")
                        .HasColumnType("boolean");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("integer");

                    b.Property<int?>("LrUnitId")
                        .HasColumnType("integer");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("integer");

                    b.Property<string>("ParcelNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Properties")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LrUnitId");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Parcel", "Parcel");
                });

            modelBuilder.Entity("Ratsatak.Domain.PossessionSheets.PossessionSheet", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<bool?>("IsHarmonized")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("integer");

                    b.Property<string>("PossessionSheetNumber")
                        .HasColumnType("text");

                    b.Property<int?>("TypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("PossessionSheet", "PossessionSheet");
                });

            modelBuilder.Entity("Ratsatak.Domain.Departments.Department", b =>
                {
                    b.HasOne("Ratsatak.Domain.Offices.Office", null)
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ratsatak.Domain.LandRegistryUnits.LandRegistryUnit", b =>
                {
                    b.HasOne("Ratsatak.Domain.Municipalities.Municipality", null)
                        .WithMany()
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Ratsatak.Domain.Municipalities.Municipality", b =>
                {
                    b.HasOne("Ratsatak.Domain.Departments.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ratsatak.Domain.Parcels.Entities.ParcelPart", b =>
                {
                    b.HasOne("Ratsatak.Domain.Parcels.Parcel", null)
                        .WithMany("ParcelParts")
                        .HasForeignKey("ParcelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ratsatak.Domain.PossessionSheets.PossessionSheet", null)
                        .WithMany()
                        .HasForeignKey("PossessionSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ratsatak.Domain.Parcels.Parcel", b =>
                {
                    b.HasOne("Ratsatak.Domain.LandRegistryUnits.LandRegistryUnit", null)
                        .WithMany()
                        .HasForeignKey("LrUnitId");

                    b.HasOne("Ratsatak.Domain.Municipalities.Municipality", null)
                        .WithMany()
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ratsatak.Domain.PossessionSheets.PossessionSheet", b =>
                {
                    b.HasOne("Ratsatak.Domain.Municipalities.Municipality", null)
                        .WithMany()
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsMany("Ratsatak.Domain.PossessionSheets.ValueObjects.Possessor", "Possessors", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Address")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<string>("Ownership")
                                .HasColumnType("text");

                            b1.Property<int>("PossessionSheetId")
                                .HasColumnType("integer");

                            b1.HasKey("Id");

                            b1.HasIndex("PossessionSheetId");

                            b1.ToTable("Possessor", "PossessionSheet");

                            b1.WithOwner()
                                .HasForeignKey("PossessionSheetId");
                        });

                    b.Navigation("Possessors");
                });

            modelBuilder.Entity("Ratsatak.Domain.Parcels.Parcel", b =>
                {
                    b.Navigation("ParcelParts");
                });
#pragma warning restore 612, 618
        }
    }
}
