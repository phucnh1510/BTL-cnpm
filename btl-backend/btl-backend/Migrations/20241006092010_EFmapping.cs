using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btl_backend.Migrations
{
    /// <inheritdoc />
    public partial class EFmapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Classes_ClassId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Problems_ProblemID",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_Problems_ProblemID",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Problems_ProblemID",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Topics_ProblemID",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ClassId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "TopicContent",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "ProblemID",
                table: "Topics",
                newName: "ProblemId");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                table: "Topics",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "ProblemID",
                table: "TestCases",
                newName: "ProblemId");

            migrationBuilder.RenameColumn(
                name: "TestCaseID",
                table: "TestCases",
                newName: "TestCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_ProblemID",
                table: "TestCases",
                newName: "IX_TestCases_ProblemId");

            migrationBuilder.RenameColumn(
                name: "ProblemID",
                table: "Submissions",
                newName: "ProblemId");

            migrationBuilder.RenameColumn(
                name: "SubmissionID",
                table: "Submissions",
                newName: "SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_ProblemID",
                table: "Submissions",
                newName: "IX_Submissions_ProblemId");

            migrationBuilder.RenameColumn(
                name: "ProblemID",
                table: "Problems",
                newName: "ProblemId");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProblemId",
                table: "Topics",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProblemId",
                table: "TestCases",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Submissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProblemId",
                table: "Submissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Submissions",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Classes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClassProblem",
                columns: table => new
                {
                    ClassesClassId = table.Column<int>(type: "integer", nullable: false),
                    ProblemsProblemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassProblem", x => new { x.ClassesClassId, x.ProblemsProblemId });
                    table.ForeignKey(
                        name: "FK_ClassProblem_Classes_ClassesClassId",
                        column: x => x.ClassesClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassProblem_Problems_ProblemsProblemId",
                        column: x => x.ProblemsProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTopic",
                columns: table => new
                {
                    ProblemsProblemId = table.Column<int>(type: "integer", nullable: false),
                    TopicsTopicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTopic", x => new { x.ProblemsProblemId, x.TopicsTopicId });
                    table.ForeignKey(
                        name: "FK_ProblemTopic_Problems_ProblemsProblemId",
                        column: x => x.ProblemsProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemTopic_Topics_TopicsTopicId",
                        column: x => x.TopicsTopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassProblem_ProblemsProblemId",
                table: "ClassProblem",
                column: "ProblemsProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemTopic_TopicsTopicId",
                table: "ProblemTopic",
                column: "TopicsTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Problems_ProblemId",
                table: "Submissions",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_Problems_ProblemId",
                table: "TestCases",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classes_ClassId",
                table: "Users",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Problems_ProblemId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_Problems_ProblemId",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ClassProblem");

            migrationBuilder.DropTable(
                name: "ProblemTopic");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ProblemId",
                table: "Topics",
                newName: "ProblemID");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Topics",
                newName: "TopicID");

            migrationBuilder.RenameColumn(
                name: "ProblemId",
                table: "TestCases",
                newName: "ProblemID");

            migrationBuilder.RenameColumn(
                name: "TestCaseId",
                table: "TestCases",
                newName: "TestCaseID");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_ProblemId",
                table: "TestCases",
                newName: "IX_TestCases_ProblemID");

            migrationBuilder.RenameColumn(
                name: "ProblemId",
                table: "Submissions",
                newName: "ProblemID");

            migrationBuilder.RenameColumn(
                name: "SubmissionId",
                table: "Submissions",
                newName: "SubmissionID");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_ProblemId",
                table: "Submissions",
                newName: "IX_Submissions_ProblemID");

            migrationBuilder.RenameColumn(
                name: "ProblemId",
                table: "Problems",
                newName: "ProblemID");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemID",
                table: "Topics",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "TopicContent",
                table: "Topics",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemID",
                table: "TestCases",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Submissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemID",
                table: "Submissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Submissions",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Problems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ProblemID",
                table: "Topics",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ClassId",
                table: "Problems",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Classes_ClassId",
                table: "Problems",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Problems_ProblemID",
                table: "Submissions",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_Problems_ProblemID",
                table: "TestCases",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Problems_ProblemID",
                table: "Topics",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classes_ClassId",
                table: "Users",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId");
        }
    }
}
