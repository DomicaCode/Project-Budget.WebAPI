using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Budget.WebAPI.Migrations
{
    public partial class adduseridtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Type",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Type_UserId",
                table: "Type",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_User_UserId",
                table: "Type",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_User_UserId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Type_UserId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Type");
        }
    }
}
