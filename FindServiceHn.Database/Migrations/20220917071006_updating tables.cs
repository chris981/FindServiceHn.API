using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindServiceHn.Database.Migrations
{
    public partial class updatingtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IStatus",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "IdCate",
                table: "QuotesHeaders",
                newName: "IdStatusCreationDate");

            migrationBuilder.RenameColumn(
                name: "IStatusCreationDate",
                table: "QuotesHeaders",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "IStatus",
                table: "QuotesHeaders",
                newName: "IdCategory");

            migrationBuilder.RenameColumn(
                name: "IStatus",
                table: "ProviderServices",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "Istatus",
                table: "ProviderEvals",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "IdDeparment",
                table: "CustomerAddresses",
                newName: "IdDepartment");

            migrationBuilder.AlterColumn<string>(
                name: "IndusCai",
                table: "Providers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IndDelivery",
                table: "Providers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AtentionLast",
                table: "Providers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AtentionFirst",
                table: "Providers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Customers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "IdStatusCreationDate",
                table: "QuotesHeaders",
                newName: "IdCate");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "QuotesHeaders",
                newName: "IStatusCreationDate");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "QuotesHeaders",
                newName: "IStatus");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "ProviderServices",
                newName: "IStatus");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "ProviderEvals",
                newName: "Istatus");

            migrationBuilder.RenameColumn(
                name: "IdDepartment",
                table: "CustomerAddresses",
                newName: "IdDeparment");

            migrationBuilder.AlterColumn<int>(
                name: "IndusCai",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IndDelivery",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "AtentionLast",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "AtentionFirst",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IStatus",
                table: "Providers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                table: "Customers",
                type: "longblob",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
