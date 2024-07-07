using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class Initial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseResults",
                table: "CourseResults");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseResults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "CourseResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseResults",
                table: "CourseResults",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseResults",
                table: "CourseResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseResults");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "CourseResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseResults",
                table: "CourseResults",
                columns: new[] { "TraineeId", "CourseId" });
        }
    }
}
