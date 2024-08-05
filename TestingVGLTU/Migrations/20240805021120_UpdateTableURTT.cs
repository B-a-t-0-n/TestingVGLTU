using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableURTT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResponsesToTests_Users_UserId",
                table: "UserResponsesToTests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserResponsesToTests",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponsesToTests_UserId",
                table: "UserResponsesToTests",
                newName: "IX_UserResponsesToTests_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponsesToTests_Students_StudentId",
                table: "UserResponsesToTests",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResponsesToTests_Students_StudentId",
                table: "UserResponsesToTests");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "UserResponsesToTests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponsesToTests_StudentId",
                table: "UserResponsesToTests",
                newName: "IX_UserResponsesToTests_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponsesToTests_Users_UserId",
                table: "UserResponsesToTests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
