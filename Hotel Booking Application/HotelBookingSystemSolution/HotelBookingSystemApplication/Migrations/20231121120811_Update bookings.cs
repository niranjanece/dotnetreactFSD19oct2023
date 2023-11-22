using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemApplication.Migrations
{
    public partial class Updatebookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Rooms_roomId",
                table: "BookingDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Rooms_roomId",
                table: "BookingDetails",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "roomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Rooms_roomId",
                table: "BookingDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Rooms_roomId",
                table: "BookingDetails",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "roomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
