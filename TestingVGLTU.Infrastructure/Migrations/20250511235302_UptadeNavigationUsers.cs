using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UptadeNavigationUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_history_Student_StudentId",
                schema: "TestingVGLTU",
                table: "history");

            migrationBuilder.DropForeignKey(
                name: "FK_layouts_testings_Teacher_TeacherId",
                schema: "TestingVGLTU",
                table: "layouts_testings");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_groups_GroupId",
                schema: "TestingVGLTU",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_users_Id",
                schema: "TestingVGLTU",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_users_Id",
                schema: "TestingVGLTU",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                schema: "TestingVGLTU",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                schema: "TestingVGLTU",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Teacher",
                schema: "TestingVGLTU",
                newName: "teachers",
                newSchema: "TestingVGLTU");

            migrationBuilder.RenameTable(
                name: "Student",
                schema: "TestingVGLTU",
                newName: "students",
                newSchema: "TestingVGLTU");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GroupId",
                schema: "TestingVGLTU",
                table: "students",
                newName: "IX_students_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teachers",
                schema: "TestingVGLTU",
                table: "teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                schema: "TestingVGLTU",
                table: "students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_history_students_StudentId",
                schema: "TestingVGLTU",
                table: "history",
                column: "StudentId",
                principalSchema: "TestingVGLTU",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_layouts_testings_teachers_TeacherId",
                schema: "TestingVGLTU",
                table: "layouts_testings",
                column: "TeacherId",
                principalSchema: "TestingVGLTU",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_groups_GroupId",
                schema: "TestingVGLTU",
                table: "students",
                column: "GroupId",
                principalSchema: "TestingVGLTU",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_users_Id",
                schema: "TestingVGLTU",
                table: "students",
                column: "Id",
                principalSchema: "TestingVGLTU",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_users_Id",
                schema: "TestingVGLTU",
                table: "teachers",
                column: "Id",
                principalSchema: "TestingVGLTU",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_history_students_StudentId",
                schema: "TestingVGLTU",
                table: "history");

            migrationBuilder.DropForeignKey(
                name: "FK_layouts_testings_teachers_TeacherId",
                schema: "TestingVGLTU",
                table: "layouts_testings");

            migrationBuilder.DropForeignKey(
                name: "FK_students_groups_GroupId",
                schema: "TestingVGLTU",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_students_users_Id",
                schema: "TestingVGLTU",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_teachers_users_Id",
                schema: "TestingVGLTU",
                table: "teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teachers",
                schema: "TestingVGLTU",
                table: "teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                schema: "TestingVGLTU",
                table: "students");

            migrationBuilder.RenameTable(
                name: "teachers",
                schema: "TestingVGLTU",
                newName: "Teacher",
                newSchema: "TestingVGLTU");

            migrationBuilder.RenameTable(
                name: "students",
                schema: "TestingVGLTU",
                newName: "Student",
                newSchema: "TestingVGLTU");

            migrationBuilder.RenameIndex(
                name: "IX_students_GroupId",
                schema: "TestingVGLTU",
                table: "Student",
                newName: "IX_Student_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                schema: "TestingVGLTU",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                schema: "TestingVGLTU",
                table: "Student",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_history_Student_StudentId",
                schema: "TestingVGLTU",
                table: "history",
                column: "StudentId",
                principalSchema: "TestingVGLTU",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_layouts_testings_Teacher_TeacherId",
                schema: "TestingVGLTU",
                table: "layouts_testings",
                column: "TeacherId",
                principalSchema: "TestingVGLTU",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_groups_GroupId",
                schema: "TestingVGLTU",
                table: "Student",
                column: "GroupId",
                principalSchema: "TestingVGLTU",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_users_Id",
                schema: "TestingVGLTU",
                table: "Student",
                column: "Id",
                principalSchema: "TestingVGLTU",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_users_Id",
                schema: "TestingVGLTU",
                table: "Teacher",
                column: "Id",
                principalSchema: "TestingVGLTU",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
