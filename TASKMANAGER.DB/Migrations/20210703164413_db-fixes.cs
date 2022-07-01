using Microsoft.EntityFrameworkCore.Migrations;

namespace TASKMANAGER.DB.Migrations
{
    public partial class dbfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserId1",
                table: "TeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_TeamUsers_UserId1",
                table: "TeamUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TeamUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "TeamUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamUsers_UserId1",
                table: "TeamUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserId1",
                table: "TeamUsers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
