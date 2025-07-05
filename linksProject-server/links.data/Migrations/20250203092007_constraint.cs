using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace links.data.Migrations
{
    public partial class constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recommends_Users_Userid",
                table: "recommends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recommends",
                table: "recommends");

            migrationBuilder.RenameTable(
                name: "recommends",
                newName: "Recommends");

            migrationBuilder.RenameIndex(
                name: "IX_recommends_Userid",
                table: "Recommends",
                newName: "IX_Recommends_Userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommends",
                table: "Recommends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommends_Users_Userid",
                table: "Recommends",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommends_Users_Userid",
                table: "Recommends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommends",
                table: "Recommends");

            migrationBuilder.RenameTable(
                name: "Recommends",
                newName: "recommends");

            migrationBuilder.RenameIndex(
                name: "IX_Recommends_Userid",
                table: "recommends",
                newName: "IX_recommends_Userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recommends",
                table: "recommends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_recommends_Users_Userid",
                table: "recommends",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
