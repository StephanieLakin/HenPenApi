using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HenPenApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EggColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Climate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    FeedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.FeedId);
                });

            migrationBuilder.CreateTable(
                name: "HealthIssues",
                columns: table => new
                {
                    HealthIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthIssueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandlingDirections = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecommendedMedications = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthIssues", x => x.HealthIssueId);
                });

            migrationBuilder.CreateTable(
                name: "Hens",
                columns: table => new
                {
                    HenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EggColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WklyEggAvg = table.Column<int>(type: "int", nullable: false),
                    HasHealthIssue = table.Column<bool>(type: "bit", nullable: false),
                    HealthIssueId = table.Column<int>(type: "int", nullable: false),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "varchar(250)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hens", x => x.HenId);
                    table.ForeignKey(
                        name: "FK_Hens_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hens_HealthIssues_HealthIssueId",
                        column: x => x.HealthIssueId,
                        principalTable: "HealthIssues",
                        principalColumn: "HealthIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumptions",
                columns: table => new
                {
                    ConsumptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HenId = table.Column<int>(type: "int", nullable: false),
                    FeedId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumptions", x => x.ConsumptionId);
                    table.ForeignKey(
                        name: "FK_Consumptions_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "FeedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumptions_Hens_HenId",
                        column: x => x.HenId,
                        principalTable: "Hens",
                        principalColumn: "HenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eggs",
                columns: table => new
                {
                    EggProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HenId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EggsCollected = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eggs", x => x.EggProductionId);
                    table.ForeignKey(
                        name: "FK_Eggs_Hens_HenId",
                        column: x => x.HenId,
                        principalTable: "Hens",
                        principalColumn: "HenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_FeedId",
                table: "Consumptions",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_HenId",
                table: "Consumptions",
                column: "HenId");

            migrationBuilder.CreateIndex(
                name: "IX_Eggs_HenId",
                table: "Eggs",
                column: "HenId");

            migrationBuilder.CreateIndex(
                name: "IX_Hens_BreedId",
                table: "Hens",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Hens_HealthIssueId",
                table: "Hens",
                column: "HealthIssueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumptions");

            migrationBuilder.DropTable(
                name: "Eggs");

            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Hens");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "HealthIssues");
        }
    }
}
