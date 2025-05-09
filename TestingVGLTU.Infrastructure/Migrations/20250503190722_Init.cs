using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "TestingVGLTU");

        migrationBuilder.CreateTable(
            name: "groups",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_groups", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "type_testings",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ratio = table.Column<decimal>(type: "numeric", nullable: false),
                title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_type_testings", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "users",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "students",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                GroupId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_students", x => x.Id);
                table.ForeignKey(
                    name: "FK_students_groups_GroupId",
                    column: x => x.GroupId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "groups",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_students_users_Id",
                    column: x => x.Id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "teachers",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_teachers", x => x.Id);
                table.ForeignKey(
                    name: "FK_teachers_users_Id",
                    column: x => x.Id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "layouts_testings",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                TypeTestingId = table.Column<Guid>(type: "uuid", nullable: false),
                time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                attemps = table.Column<int>(type: "integer", nullable: false),
                title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                type_out_put = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_layouts_testings", x => x.Id);
                table.ForeignKey(
                    name: "FK_layouts_testings_teachers_TeacherId",
                    column: x => x.TeacherId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "teachers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_layouts_testings_type_testings_TypeTestingId",
                    column: x => x.TypeTestingId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "type_testings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "active_testing",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_complite = table.Column<bool>(type: "boolean", nullable: false),
                LayoutTestingId = table.Column<Guid>(type: "uuid", nullable: false),
                GroupId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_active_testing", x => x.Id);
                table.ForeignKey(
                    name: "FK_active_testing_groups_GroupId",
                    column: x => x.GroupId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "groups",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_active_testing_layouts_testings_LayoutTestingId",
                    column: x => x.LayoutTestingId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "layouts_testings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "questions",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                layout_testing_id = table.Column<Guid>(type: "uuid", nullable: true),
                scores = table.Column<int>(type: "integer", nullable: false),
                serial_number = table.Column<int>(type: "integer", nullable: false),
                text = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_questions", x => x.Id);
                table.ForeignKey(
                    name: "FK_questions_layouts_testings_layout_testing_id",
                    column: x => x.layout_testing_id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "layouts_testings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "history",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ActiveTestingId = table.Column<Guid>(type: "uuid", nullable: false),
                StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                is_complite = table.Column<bool>(type: "boolean", nullable: false),
                time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                attemp = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_history", x => x.Id);
                table.ForeignKey(
                    name: "FK_history_active_testing_ActiveTestingId",
                    column: x => x.ActiveTestingId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "active_testing",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_history_students_StudentId",
                    column: x => x.StudentId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "question_multiple_choice",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                correct_answers = table.Column<string>(type: "jsonb", nullable: false),
                answer_options = table.Column<string>(type: "jsonb", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_question_multiple_choice", x => x.Id);
                table.ForeignKey(
                    name: "FK_question_multiple_choice_questions_Id",
                    column: x => x.Id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "questions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "questions_input_number",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                correct_answers = table.Column<string>(type: "jsonb", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_questions_input_number", x => x.Id);
                table.ForeignKey(
                    name: "FK_questions_input_number_questions_Id",
                    column: x => x.Id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "questions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "questions_input_text",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                correct_answers = table.Column<string>(type: "jsonb", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_questions_input_text", x => x.Id);
                table.ForeignKey(
                    name: "FK_questions_input_text_questions_Id",
                    column: x => x.Id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "questions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "questions_single_selection",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                answer_options = table.Column<string>(type: "jsonb", nullable: false),
                right_answer = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_questions_single_selection", x => x.Id);
                table.ForeignKey(
                    name: "FK_questions_single_selection_questions_Id",
                    column: x => x.Id,
                    principalSchema: "TestingVGLTU",
                    principalTable: "questions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "user_response",
            schema: "TestingVGLTU",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                HistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                response = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                is_correct = table.Column<bool>(type: "boolean", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_user_response", x => x.Id);
                table.ForeignKey(
                    name: "FK_user_response_history_HistoryId",
                    column: x => x.HistoryId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "history",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_user_response_questions_QuestionId",
                    column: x => x.QuestionId,
                    principalSchema: "TestingVGLTU",
                    principalTable: "questions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_active_testing_GroupId",
            schema: "TestingVGLTU",
            table: "active_testing",
            column: "GroupId");

        migrationBuilder.CreateIndex(
            name: "IX_active_testing_LayoutTestingId",
            schema: "TestingVGLTU",
            table: "active_testing",
            column: "LayoutTestingId");

        migrationBuilder.CreateIndex(
            name: "IX_history_ActiveTestingId",
            schema: "TestingVGLTU",
            table: "history",
            column: "ActiveTestingId");

        migrationBuilder.CreateIndex(
            name: "IX_history_StudentId",
            schema: "TestingVGLTU",
            table: "history",
            column: "StudentId");

        migrationBuilder.CreateIndex(
            name: "IX_layouts_testings_TeacherId",
            schema: "TestingVGLTU",
            table: "layouts_testings",
            column: "TeacherId");

        migrationBuilder.CreateIndex(
            name: "IX_layouts_testings_TypeTestingId",
            schema: "TestingVGLTU",
            table: "layouts_testings",
            column: "TypeTestingId");

        migrationBuilder.CreateIndex(
            name: "IX_questions_layout_testing_id",
            schema: "TestingVGLTU",
            table: "questions",
            column: "layout_testing_id");

        migrationBuilder.CreateIndex(
            name: "IX_students_GroupId",
            schema: "TestingVGLTU",
            table: "students",
            column: "GroupId");

        migrationBuilder.CreateIndex(
            name: "IX_user_response_HistoryId",
            schema: "TestingVGLTU",
            table: "user_response",
            column: "HistoryId");

        migrationBuilder.CreateIndex(
            name: "IX_user_response_QuestionId",
            schema: "TestingVGLTU",
            table: "user_response",
            column: "QuestionId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "question_multiple_choice",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "questions_input_number",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "questions_input_text",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "questions_single_selection",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "user_response",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "history",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "questions",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "active_testing",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "students",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "layouts_testings",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "groups",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "teachers",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "type_testings",
            schema: "TestingVGLTU");

        migrationBuilder.DropTable(
            name: "users",
            schema: "TestingVGLTU");
    }
}
