using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDeleteInUploadedCsvToCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecommenderToUploadedCSVs_RecommenderConfigurations_ConfigurationId",
                table: "RecommenderToUploadedCSVs");

            migrationBuilder.AddForeignKey(
                name: "FK_RecommenderToUploadedCSVs_RecommenderConfigurations_ConfigurationId",
                table: "RecommenderToUploadedCSVs",
                column: "ConfigurationId",
                principalTable: "RecommenderConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecommenderToUploadedCSVs_RecommenderConfigurations_ConfigurationId",
                table: "RecommenderToUploadedCSVs");

            migrationBuilder.AddForeignKey(
                name: "FK_RecommenderToUploadedCSVs_RecommenderConfigurations_ConfigurationId",
                table: "RecommenderToUploadedCSVs",
                column: "ConfigurationId",
                principalTable: "RecommenderConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
