using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class Initial03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_AccountId",
                table: "Instructors",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Accounts_AccountId",
                table: "Instructors",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Accounts_AccountId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_AccountId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Accounts");
        }
    }
}
