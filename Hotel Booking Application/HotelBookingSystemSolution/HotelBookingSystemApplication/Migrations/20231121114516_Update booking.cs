using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemApplication.Migrations
{
    public partial class Updatebooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "checkIn",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "checkOut",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "checkIn",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "checkOut",
                table: "BookingDetails");
        }
    }
}
