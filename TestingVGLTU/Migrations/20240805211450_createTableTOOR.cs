using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingVGLTU.Migrations
{
    /// <inheritdoc />
    public partial class createTableTOOR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypeTestings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TypeOutputOfResultId",
                table: "Testings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOutputOfResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOutputOfResults", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeOutputOfResults",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "По окончанию" },
                    { 2, "По завершению тестирования" }
                });

            migrationBuilder.InsertData(
                table: "TypeTestings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Олимпиада" },
                    { 2, "Тест" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeTestings_Name",
                table: "TypeTestings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testings_TypeOutputOfResultId",
                table: "Testings",
                column: "TypeOutputOfResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOutputOfResults_Name",
                table: "TypeOutputOfResults",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testings_TypeOutputOfResults_TypeOutputOfResultId",
                table: "Testings",
                column: "TypeOutputOfResultId",
                principalTable: "TypeOutputOfResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testings_TypeOutputOfResults_TypeOutputOfResultId",
                table: "Testings");

            migrationBuilder.DropTable(
                name: "TypeOutputOfResults");

            migrationBuilder.DropIndex(
                name: "IX_TypeTestings_Name",
                table: "TypeTestings");

            migrationBuilder.DropIndex(
                name: "IX_Testings_TypeOutputOfResultId",
                table: "Testings");

            migrationBuilder.DeleteData(
                table: "TypeTestings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeTestings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TypeOutputOfResultId",
                table: "Testings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypeTestings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
