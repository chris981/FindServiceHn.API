using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindServiceHn.Database.Migrations
{
    public partial class updatingmunicipality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDeparment",
                table: "Municipalities",
                newName: "IdDepartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDepartment",
                table: "Municipalities",
                newName: "IdDeparment");
        }
    }
}
