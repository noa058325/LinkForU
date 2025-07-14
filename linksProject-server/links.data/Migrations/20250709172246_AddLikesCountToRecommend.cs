using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace links.data.Migrations
{
    public partial class AddLikesCountToRecommend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Recommends",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Recommends");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "name");
        }
    }
}
