using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UserGear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GearId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GearId",
                table: "Users",
                column: "GearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gears_GearId",
                table: "Users",
                column: "GearId",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gears_GearId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GearId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GearId",
                table: "Users");
        }
    }
}
