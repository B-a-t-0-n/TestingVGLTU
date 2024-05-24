using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingVGLTU.Migrations
{
    /// <inheritdoc />
    public partial class add_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTestings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTestings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberRecordBook = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTestingId = table.Column<int>(type: "int", nullable: false),
                    Attempts = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testings_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testings_TypeTestings_TypeTestingId",
                        column: x => x.TypeTestingId,
                        principalTable: "TypeTestings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveTesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    TestingId = table.Column<int>(type: "int", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveTesting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveTesting_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveTesting_Testings_TestingId",
                        column: x => x.TestingId,
                        principalTable: "Testings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scores = table.Column<int>(type: "int", nullable: false),
                    TestingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Testings_TestingId",
                        column: x => x.TestingId,
                        principalTable: "Testings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionInputNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionInputNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionInputNumbers_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionInputText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionInputText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionInputText_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionMultipleChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AnswerOptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionMultipleChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionMultipleChoices_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSingleSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AnswerOptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSingleSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSingleSelections_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResponsesToTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ActiveTestingId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResponsesToTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResponsesToTests_ActiveTesting_ActiveTestingId",
                        column: x => x.ActiveTestingId,
                        principalTable: "ActiveTesting",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserResponsesToTests_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserResponsesToTests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTesting_GroupId",
                table: "ActiveTesting",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTesting_TestingId",
                table: "ActiveTesting",
                column: "TestingId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestingId",
                table: "Questions",
                column: "TestingId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_TeacherId",
                table: "Testings",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_TypeTestingId",
                table: "Testings",
                column: "TypeTestingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponsesToTests_ActiveTestingId",
                table: "UserResponsesToTests",
                column: "ActiveTestingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponsesToTests_QuestionId",
                table: "UserResponsesToTests",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponsesToTests_UserId",
                table: "UserResponsesToTests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionInputNumbers");

            migrationBuilder.DropTable(
                name: "QuestionInputText");

            migrationBuilder.DropTable(
                name: "QuestionMultipleChoices");

            migrationBuilder.DropTable(
                name: "QuestionSingleSelections");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserResponsesToTests");

            migrationBuilder.DropTable(
                name: "ActiveTesting");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Testings");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "TypeTestings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
