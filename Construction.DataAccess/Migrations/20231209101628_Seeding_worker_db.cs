using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_worker_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactInformation",
                table: "Workers",
                newName: "WorkTitle");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerId", "LastName", "Name", "Number", "WorkTitle" },
                values: new object[,]
                {
                    { 1, "Piotr", "Jhon", "+37060606060", "Betonuotojas" },
                    { 2, "Snow", "Matt", "+37067989898", "Apdailininkas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "WorkerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "WorkerId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "WorkTitle",
                table: "Workers",
                newName: "ContactInformation");
        }
    }
}
