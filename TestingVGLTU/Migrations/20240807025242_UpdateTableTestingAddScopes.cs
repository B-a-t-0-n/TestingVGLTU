using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTestingAddScopes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoresFor3",
                table: "Testings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoresFor4",
                table: "Testings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoresFor5",
                table: "Testings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoresFor3",
                table: "Testings");

            migrationBuilder.DropColumn(
                name: "ScoresFor4",
                table: "Testings");

            migrationBuilder.DropColumn(
                name: "ScoresFor5",
                table: "Testings");
        }
    }
}
