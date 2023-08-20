using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ratsatak.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Department");

            migrationBuilder.EnsureSchema(
                name: "LandRegistryUnit");

            migrationBuilder.EnsureSchema(
                name: "Municipality");

            migrationBuilder.EnsureSchema(
                name: "Office");

            migrationBuilder.EnsureSchema(
                name: "Parcel");

            migrationBuilder.EnsureSchema(
                name: "PossessionSheet");

            migrationBuilder.CreateTable(
                name: "Office",
                schema: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OfficeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "Office",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                schema: "Municipality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegNum = table.Column<int>(type: "integer", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Scraped = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipality_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Department",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandRegistryUnit",
                schema: "LandRegistryUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    LandRegistryUnitNumber = table.Column<string>(type: "text", nullable: true),
                    MunicipalityId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Verificated = table.Column<bool>(type: "boolean", nullable: true),
                    Condominiums = table.Column<bool>(type: "boolean", nullable: true),
                    MainBookId = table.Column<int>(type: "integer", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandRegistryUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandRegistryUnit_Municipality_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "Municipality",
                        principalTable: "Municipality",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PossessionSheet",
                schema: "PossessionSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    PossessionSheetNumber = table.Column<string>(type: "text", nullable: true),
                    TypeId = table.Column<int>(type: "integer", nullable: true),
                    MunicipalityId = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IsHarmonized = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossessionSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PossessionSheet_Municipality_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "Municipality",
                        principalTable: "Municipality",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                schema: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Geometry = table.Column<string>(type: "text", nullable: true),
                    ParcelNumber = table.Column<string>(type: "text", nullable: false),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    InstitutionId = table.Column<int>(type: "integer", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    BuildingRemark = table.Column<int>(type: "integer", nullable: true),
                    DetailSheetNumber = table.Column<string>(type: "text", nullable: true),
                    HasBuildingRight = table.Column<bool>(type: "boolean", nullable: true),
                    MunicipalityId = table.Column<int>(type: "integer", nullable: false),
                    LrUnitId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_LandRegistryUnit_LrUnitId",
                        column: x => x.LrUnitId,
                        principalSchema: "LandRegistryUnit",
                        principalTable: "LandRegistryUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parcel_Municipality_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "Municipality",
                        principalTable: "Municipality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Possessor",
                schema: "PossessionSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Ownership = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PossessionSheetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Possessor_PossessionSheet_PossessionSheetId",
                        column: x => x.PossessionSheetId,
                        principalSchema: "PossessionSheet",
                        principalTable: "PossessionSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelPart",
                schema: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    ParcelId = table.Column<int>(type: "integer", nullable: false),
                    PossessionSheetId = table.Column<int>(type: "integer", nullable: false),
                    LastChangeLogNumber = table.Column<string>(type: "text", nullable: true),
                    Building = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelPart_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalSchema: "Parcel",
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelPart_PossessionSheet_PossessionSheetId",
                        column: x => x.PossessionSheetId,
                        principalSchema: "PossessionSheet",
                        principalTable: "PossessionSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_OfficeId",
                schema: "Department",
                table: "Department",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandRegistryUnit_MunicipalityId",
                schema: "LandRegistryUnit",
                table: "LandRegistryUnit",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_DepartmentId",
                schema: "Municipality",
                table: "Municipality",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_LrUnitId",
                schema: "Parcel",
                table: "Parcel",
                column: "LrUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_MunicipalityId",
                schema: "Parcel",
                table: "Parcel",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelPart_ParcelId",
                schema: "Parcel",
                table: "ParcelPart",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelPart_PossessionSheetId",
                schema: "Parcel",
                table: "ParcelPart",
                column: "PossessionSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_PossessionSheet_MunicipalityId",
                schema: "PossessionSheet",
                table: "PossessionSheet",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Possessor_PossessionSheetId",
                schema: "PossessionSheet",
                table: "Possessor",
                column: "PossessionSheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParcelPart",
                schema: "Parcel");

            migrationBuilder.DropTable(
                name: "Possessor",
                schema: "PossessionSheet");

            migrationBuilder.DropTable(
                name: "Parcel",
                schema: "Parcel");

            migrationBuilder.DropTable(
                name: "PossessionSheet",
                schema: "PossessionSheet");

            migrationBuilder.DropTable(
                name: "LandRegistryUnit",
                schema: "LandRegistryUnit");

            migrationBuilder.DropTable(
                name: "Municipality",
                schema: "Municipality");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Department");

            migrationBuilder.DropTable(
                name: "Office",
                schema: "Office");
        }
    }
}
