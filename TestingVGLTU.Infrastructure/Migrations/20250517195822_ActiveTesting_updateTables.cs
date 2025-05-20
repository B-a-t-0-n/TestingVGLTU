using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActiveTesting_updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_active_testing_groups_GroupId",
                schema: "TestingVGLTU",
                table: "active_testing");

            migrationBuilder.DropForeignKey(
                name: "FK_user_response_questions_QuestionId",
                schema: "TestingVGLTU",
                table: "user_response");

            migrationBuilder.DropIndex(
                name: "IX_active_testing_GroupId",
                schema: "TestingVGLTU",
                table: "active_testing");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "TestingVGLTU",
                table: "active_testing");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                schema: "TestingVGLTU",
                table: "user_response",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "groups_id",
                schema: "TestingVGLTU",
                table: "active_testing",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_user_response_questions_QuestionId",
                schema: "TestingVGLTU",
                table: "user_response",
                column: "QuestionId",
                principalSchema: "TestingVGLTU",
                principalTable: "questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_response_questions_QuestionId",
                schema: "TestingVGLTU",
                table: "user_response");

            migrationBuilder.DropColumn(
                name: "groups_id",
                schema: "TestingVGLTU",
                table: "active_testing");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                schema: "TestingVGLTU",
                table: "user_response",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "TestingVGLTU",
                table: "active_testing",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_active_testing_GroupId",
                schema: "TestingVGLTU",
                table: "active_testing",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_active_testing_groups_GroupId",
                schema: "TestingVGLTU",
                table: "active_testing",
                column: "GroupId",
                principalSchema: "TestingVGLTU",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_response_questions_QuestionId",
                schema: "TestingVGLTU",
                table: "user_response",
                column: "QuestionId",
                principalSchema: "TestingVGLTU",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
