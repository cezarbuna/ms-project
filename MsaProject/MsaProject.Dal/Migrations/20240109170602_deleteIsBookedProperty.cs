using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MsaProject.Dal.Migrations
{
    /// <inheritdoc />
    public partial class deleteIsBookedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Tables");

            migrationBuilder.RenameColumn(
                name: "ReservationTime",
                table: "Reservations",
                newName: "ReservationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservations",
                newName: "ReservationTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
