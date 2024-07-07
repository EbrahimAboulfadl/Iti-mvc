using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class Initial06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Courses_TraineeId",
                table: "CourseResults");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_CourseId",
                table: "CourseResults",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Courses_CourseId",
                table: "CourseResults",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Courses_CourseId",
                table: "CourseResults");

            migrationBuilder.DropIndex(
                name: "IX_CourseResults_CourseId",
                table: "CourseResults");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Courses_TraineeId",
                table: "CourseResults",
                column: "TraineeId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
