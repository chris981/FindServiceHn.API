using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindServiceHn.Database.Migrations
{
    public partial class Adtablescustomerdepartamentcountriesmunicipalities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider_Services",
                table: "Provider_Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider_Plan_Jobs",
                table: "Provider_Plan_Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_provider_Evals",
                table: "provider_Evals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_status",
                table: "Order_status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_satisfactions",
                table: "Order_satisfactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Details",
                table: "Order_Details");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Provider_Services",
                newName: "ProviderServices");

            migrationBuilder.RenameTable(
                name: "Provider_Plan_Jobs",
                newName: "ProviderPlanJobs");

            migrationBuilder.RenameTable(
                name: "provider_Evals",
                newName: "ProviderEvals");

            migrationBuilder.RenameTable(
                name: "Order_status",
                newName: "Orderstatus");

            migrationBuilder.RenameTable(
                name: "Order_satisfactions",
                newName: "Ordersatisfactions");

            migrationBuilder.RenameTable(
                name: "Order_Details",
                newName: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "IStatus",
                table: "ServicesStatuss",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "IStatus",
                table: "ProvidersAttentions",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "IdProvider");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Categories",
                newName: "IdUserCreation");

            migrationBuilder.AlterColumn<int>(
                name: "IdProvider",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProviderPlanJobs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "IdProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderServices",
                table: "ProviderServices",
                column: "IdProviderService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderPlanJobs",
                table: "ProviderPlanJobs",
                column: "IdQtyWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProviderEvals",
                table: "ProviderEvals",
                column: "IdEval");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderstatus",
                table: "Orderstatus",
                column: "IdStatusOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordersatisfactions",
                table: "Ordersatisfactions",
                column: "IdSatisfaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "IdOrder");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdUserCreation = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.IdCountry);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    IdCustomerAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdDeparment = table.Column<int>(type: "int", nullable: false),
                    IdMunicipality = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observations = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.IdCustomerAddress);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    emailpassword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rtn = table.Column<int>(type: "int", nullable: false),
                    Identificationcard = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCustomerAddress = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Department = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Municipality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfilePicture = table.Column<byte[]>(type: "longblob", nullable: false),
                    MainProfile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KeyValidation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DayHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hour = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayHours", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    IdDepartment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUserCreation = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.IdDepartment);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    IdMunicipality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdDeparment = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUserCreation = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.IdMunicipality);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdProvider = table.Column<int>(type: "int", nullable: false),
                    IdClientAddress = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdSubCategory = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    SatisfactionLevel = table.Column<int>(type: "int", nullable: false),
                    CustomerObservation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.IdOrder);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DayHours");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderServices",
                table: "ProviderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderPlanJobs",
                table: "ProviderPlanJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProviderEvals",
                table: "ProviderEvals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderstatus",
                table: "Orderstatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordersatisfactions",
                table: "Ordersatisfactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShippingStatus",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProviderServices",
                newName: "Provider_Services");

            migrationBuilder.RenameTable(
                name: "ProviderPlanJobs",
                newName: "Provider_Plan_Jobs");

            migrationBuilder.RenameTable(
                name: "ProviderEvals",
                newName: "provider_Evals");

            migrationBuilder.RenameTable(
                name: "Orderstatus",
                newName: "Order_status");

            migrationBuilder.RenameTable(
                name: "Ordersatisfactions",
                newName: "Order_satisfactions");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "Order_Details");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "ServicesStatuss",
                newName: "IStatus");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "ProvidersAttentions",
                newName: "IStatus");

            migrationBuilder.RenameColumn(
                name: "IdProvider",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdUserCreation",
                table: "Categories",
                newName: "CreatedBy");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CreationDate",
                table: "Provider_Plan_Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider_Services",
                table: "Provider_Services",
                column: "IdProviderService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider_Plan_Jobs",
                table: "Provider_Plan_Jobs",
                column: "IdQtyWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_provider_Evals",
                table: "provider_Evals",
                column: "IdEval");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_status",
                table: "Order_status",
                column: "IdStatusOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_satisfactions",
                table: "Order_satisfactions",
                column: "IdSatisfaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Details",
                table: "Order_Details",
                column: "IdOrder");
        }
    }
}
