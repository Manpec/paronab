using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplicationParonAB.Migrations
{
    /// <inheritdoc />
    public partial class seedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produkter",
                columns: new[] { "Produktnr", "Benamning", "Pris" },
                values: new object[,]
                {
                    { "P002", "jPlatta", 8000 },
                    { "P003", "Päronklocka", 12000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produkter",
                keyColumn: "Produktnr",
                keyValue: "P002");

            migrationBuilder.DeleteData(
                table: "Produkter",
                keyColumn: "Produktnr",
                keyValue: "P003");
        }
    }
}
