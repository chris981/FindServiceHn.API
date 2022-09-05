using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindServiceHn.Database.Migrations
{
    public partial class addingorderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "SubCategories",
                newName: "IdUserCreation");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SubCategories",
                newName: "IdCategory");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubCategories",
                newName: "IdSubCategories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DayHours",
                newName: "IdHour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUserCreation",
                table: "SubCategories",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "SubCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "IdSubCategories",
                table: "SubCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdHour",
                table: "DayHours",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
