using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class ChallengeSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Challenges",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_SportId",
                table: "Challenges",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Sports_SportId",
                table: "Challenges",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Sports_SportId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_SportId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Challenges");
        }
    }
}
