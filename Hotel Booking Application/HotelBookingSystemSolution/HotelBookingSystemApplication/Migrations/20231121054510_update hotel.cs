using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingSystemApplication.Migrations
{
    public partial class updatehotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalRoom",
                table: "Rooms",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Hotels",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Hotels",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Email",
                table: "Hotels",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Users_Email",
                table: "Hotels",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Users_Email",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_Email",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Rooms",
                newName: "totalRoom");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Hotels",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Hotels",
                newName: "password");
        }
    }
}
