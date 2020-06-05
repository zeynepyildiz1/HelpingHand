using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHandProject.Data.Migrations
{
    public partial class LikeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LikeStatus",
                table: "Likes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeStatus",
                table: "Likes");
        }
    }
}
