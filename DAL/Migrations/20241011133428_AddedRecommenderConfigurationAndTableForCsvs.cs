using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecommenderConfigurationAndTableForCsvs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecommenderConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlgorithmType = table.Column<int>(type: "int", nullable: false),
                    DataSourceType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommenderConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommenderConfigurations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommenderToUploadedCSVs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedCsvId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommenderToUploadedCSVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommenderToUploadedCSVs_RecommenderConfigurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "RecommenderConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommenderToUploadedCSVs_UploadedCSVs_UploadedCsvId",
                        column: x => x.UploadedCsvId,
                        principalTable: "UploadedCSVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecommenderConfigurations_ClientId",
                table: "RecommenderConfigurations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommenderToUploadedCSVs_ConfigurationId",
                table: "RecommenderToUploadedCSVs",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommenderToUploadedCSVs_UploadedCsvId",
                table: "RecommenderToUploadedCSVs",
                column: "UploadedCsvId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecommenderToUploadedCSVs");

            migrationBuilder.DropTable(
                name: "RecommenderConfigurations");
        }
    }
}
