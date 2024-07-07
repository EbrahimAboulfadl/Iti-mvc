using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class Initial04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trainees_DepartmentId",
                table: "Trainees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DepartmentId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_DepartmentId",
                table: "Trainees");
        }
    }
}
