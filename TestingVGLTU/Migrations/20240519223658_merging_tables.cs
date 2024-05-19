using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Migrations
{
    /// <inheritdoc />
    public partial class merging_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Testings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Testings_TeacherId",
                table: "Testings",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testings_Teachers_TeacherId",
                table: "Testings",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testings_Teachers_TeacherId",
                table: "Testings");

            migrationBuilder.DropIndex(
                name: "IX_Testings_TeacherId",
                table: "Testings");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Testings");
        }
    }
}
