using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebShoppie.DataModel.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shoppie");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Shoppie",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Addressline1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Addressline2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Addressline3 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Shoppie",
                columns: table => new
                {
                    Productid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StockCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Productid);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Shoppie",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Shoppie",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderproducts",
                schema: "Shoppie",
                columns: table => new
                {
                    OrderProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Productid = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderproducts", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_Orderproducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Shoppie",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderproducts_Products_Productid",
                        column: x => x.Productid,
                        principalSchema: "Shoppie",
                        principalTable: "Products",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orderproducts_OrderId",
                schema: "Shoppie",
                table: "Orderproducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderproducts_Productid",
                schema: "Shoppie",
                table: "Orderproducts",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Shoppie",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orderproducts",
                schema: "Shoppie");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Shoppie");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Shoppie");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Shoppie");
        }
    }
}
