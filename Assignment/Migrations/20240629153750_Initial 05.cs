using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class Initial05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_TraineeId",
                table: "CourseResults",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Courses_TraineeId",
                table: "CourseResults",
                column: "TraineeId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResults_Trainees_TraineeId",
                table: "CourseResults",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Courses_TraineeId",
                table: "CourseResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Trainees_TraineeId",
                table: "CourseResults");

            migrationBuilder.DropIndex(
                name: "IX_CourseResults_TraineeId",
                table: "CourseResults");
        }
    }
}
