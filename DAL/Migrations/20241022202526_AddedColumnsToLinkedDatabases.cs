using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnsToLinkedDatabases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatabaseCredentials",
                table: "LinkedDatabases",
                newName: "DatabaseLink");

            migrationBuilder.AddColumn<string>(
                name: "DatabaseConfigurationId",
                table: "LinkedDatabases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasRatings",
                table: "LinkedDatabases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasViews",
                table: "LinkedDatabases",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatabaseConfigurationId",
                table: "LinkedDatabases");

            migrationBuilder.DropColumn(
                name: "HasRatings",
                table: "LinkedDatabases");

            migrationBuilder.DropColumn(
                name: "HasViews",
                table: "LinkedDatabases");

            migrationBuilder.RenameColumn(
                name: "DatabaseLink",
                table: "LinkedDatabases",
                newName: "DatabaseCredentials");
        }
    }
}
