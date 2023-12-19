using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class teeesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Projects_Worker",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_Worker",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Worker",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Worker",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_Worker",
                table: "Workers",
                column: "Worker");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Projects_Worker",
                table: "Workers",
                column: "Worker",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
