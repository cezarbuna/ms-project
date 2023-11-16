using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MsaProject.Dal.Migrations
{
    /// <inheritdoc />
    public partial class updatedTableClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Tables");
        }
    }
}
