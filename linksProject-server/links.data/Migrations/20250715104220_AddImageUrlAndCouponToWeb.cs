using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace links.data.Migrations
{
    public partial class AddImageUrlAndCouponToWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coupon",
                table: "Webs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Webs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coupon",
                table: "Webs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Webs");
        }
    }
}
