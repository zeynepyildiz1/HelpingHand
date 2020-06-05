using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHandProject.Data.Migrations
{
    public partial class UpdateLike2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LikeDate",
                table: "Likes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeDate",
                table: "Likes");
        }
    }
}
