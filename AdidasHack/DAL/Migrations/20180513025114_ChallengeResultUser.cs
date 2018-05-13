using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class ChallengeResultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ChallengeResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeResults_UserId",
                table: "ChallengeResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengeResults_Users_UserId",
                table: "ChallengeResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengeResults_Users_UserId",
                table: "ChallengeResults");

            migrationBuilder.DropIndex(
                name: "IX_ChallengeResults_UserId",
                table: "ChallengeResults");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChallengeResults");
        }
    }
}
