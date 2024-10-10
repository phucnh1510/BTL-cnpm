using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btl_backend.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionIncreaseSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemContent",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "ProblemName",
                table: "Problems",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Problems",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Problems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Solution",
                table: "Problems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Problems",
                newName: "ProblemName");

            migrationBuilder.AddColumn<string>(
                name: "ProblemContent",
                table: "Problems",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
