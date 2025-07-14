using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace links.data.Migrations
{
    public partial class RenamePhoneNumberField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNamber",
                table: "Users",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "PhoneNamber");
        }
    }
}
