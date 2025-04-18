using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FotoToestellenApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Merken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WebsiteUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merken", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FotoToestellen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdviesPrijs = table.Column<double>(type: "double", nullable: false),
                    BeschikbaarSinds = table.Column<DateOnly>(type: "date", nullable: false),
                    MerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoToestellen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoToestellen_Merken_MerkId",
                        column: x => x.MerkId,
                        principalTable: "Merken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lenzen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdviesPrijs = table.Column<double>(type: "double", nullable: false),
                    GewichtG = table.Column<double>(type: "double", nullable: false),
                    Mount = table.Column<int>(type: "int", nullable: false),
                    MerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenzen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lenzen_Merken_MerkId",
                        column: x => x.MerkId,
                        principalTable: "Merken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FotoToestelLens",
                columns: table => new
                {
                    CompatibeleFotoToestellenId = table.Column<int>(type: "int", nullable: false),
                    CompatibeleLenzenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoToestelLens", x => new { x.CompatibeleFotoToestellenId, x.CompatibeleLenzenId });
                    table.ForeignKey(
                        name: "FK_FotoToestelLens_FotoToestellen_CompatibeleFotoToestellenId",
                        column: x => x.CompatibeleFotoToestellenId,
                        principalTable: "FotoToestellen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotoToestelLens_Lenzen_CompatibeleLenzenId",
                        column: x => x.CompatibeleLenzenId,
                        principalTable: "Lenzen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FotoToestellen_MerkId",
                table: "FotoToestellen",
                column: "MerkId");

            migrationBuilder.CreateIndex(
                name: "IX_FotoToestellen_Model",
                table: "FotoToestellen",
                column: "Model",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FotoToestelLens_CompatibeleLenzenId",
                table: "FotoToestelLens",
                column: "CompatibeleLenzenId");

            migrationBuilder.CreateIndex(
                name: "IX_Lenzen_MerkId_Model",
                table: "Lenzen",
                columns: new[] { "MerkId", "Model" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merken_Naam",
                table: "Merken",
                column: "Naam",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotoToestelLens");

            migrationBuilder.DropTable(
                name: "FotoToestellen");

            migrationBuilder.DropTable(
                name: "Lenzen");

            migrationBuilder.DropTable(
                name: "Merken");
        }
    }
}
