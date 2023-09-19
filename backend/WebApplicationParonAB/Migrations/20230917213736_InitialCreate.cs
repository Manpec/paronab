using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationParonAB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fardigvarulager",
                columns: table => new
                {
                    Lagernr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fardigvarulager", x => x.Lagernr);
                });

            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    Produktnr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Benamning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.Produktnr);
                });

            migrationBuilder.CreateTable(
                name: "FardigvarulagerProdukter",
                columns: table => new
                {
                    FardigvarulagerLagernr = table.Column<int>(type: "int", nullable: false),
                    ProdukterProduktnr = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FardigvarulagerProdukter", x => new { x.FardigvarulagerLagernr, x.ProdukterProduktnr });
                    table.ForeignKey(
                        name: "FK_FardigvarulagerProdukter_Fardigvarulager_FardigvarulagerLagernr",
                        column: x => x.FardigvarulagerLagernr,
                        principalTable: "Fardigvarulager",
                        principalColumn: "Lagernr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FardigvarulagerProdukter_Produkter_ProdukterProduktnr",
                        column: x => x.ProdukterProduktnr,
                        principalTable: "Produkter",
                        principalColumn: "Produktnr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InOchUtLeverans",
                columns: table => new
                {
                    Leveransnr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Produkt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Till_eller_fran = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FardigvarulagerLagernr = table.Column<int>(type: "int", nullable: true),
                    ProdukterProduktnr = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOchUtLeverans", x => x.Leveransnr);
                    table.ForeignKey(
                        name: "FK_InOchUtLeverans_Fardigvarulager_FardigvarulagerLagernr",
                        column: x => x.FardigvarulagerLagernr,
                        principalTable: "Fardigvarulager",
                        principalColumn: "Lagernr");
                    table.ForeignKey(
                        name: "FK_InOchUtLeverans_Produkter_ProdukterProduktnr",
                        column: x => x.ProdukterProduktnr,
                        principalTable: "Produkter",
                        principalColumn: "Produktnr");
                });

            migrationBuilder.CreateTable(
                name: "Lagersaldo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produkt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fardigvarulager = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    ProduktrefProduktnr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniqueIndex = table.Column<int>(type: "int", nullable: false),
                    FardigvarulagerLagernr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagersaldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lagersaldo_Fardigvarulager_FardigvarulagerLagernr",
                        column: x => x.FardigvarulagerLagernr,
                        principalTable: "Fardigvarulager",
                        principalColumn: "Lagernr");
                    table.ForeignKey(
                        name: "FK_Lagersaldo_Produkter_ProduktrefProduktnr",
                        column: x => x.ProduktrefProduktnr,
                        principalTable: "Produkter",
                        principalColumn: "Produktnr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fardigvarulager_Stad",
                table: "Fardigvarulager",
                column: "Stad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FardigvarulagerProdukter_ProdukterProduktnr",
                table: "FardigvarulagerProdukter",
                column: "ProdukterProduktnr");

            migrationBuilder.CreateIndex(
                name: "IX_InOchUtLeverans_FardigvarulagerLagernr",
                table: "InOchUtLeverans",
                column: "FardigvarulagerLagernr");

            migrationBuilder.CreateIndex(
                name: "IX_InOchUtLeverans_ProdukterProduktnr",
                table: "InOchUtLeverans",
                column: "ProdukterProduktnr");

            migrationBuilder.CreateIndex(
                name: "IX_Lagersaldo_FardigvarulagerLagernr",
                table: "Lagersaldo",
                column: "FardigvarulagerLagernr");

            migrationBuilder.CreateIndex(
                name: "IX_Lagersaldo_Produkt_Fardigvarulager",
                table: "Lagersaldo",
                columns: new[] { "Produkt", "Fardigvarulager" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lagersaldo_ProduktrefProduktnr",
                table: "Lagersaldo",
                column: "ProduktrefProduktnr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FardigvarulagerProdukter");

            migrationBuilder.DropTable(
                name: "InOchUtLeverans");

            migrationBuilder.DropTable(
                name: "Lagersaldo");

            migrationBuilder.DropTable(
                name: "Fardigvarulager");

            migrationBuilder.DropTable(
                name: "Produkter");
        }
    }
}
