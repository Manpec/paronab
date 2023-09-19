using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationParonAB.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produkter",
                columns: new[] { "Produktnr", "Benamning", "Pris" },
                values: new object[] { "P001", "jTelefon", 6000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produkter",
                keyColumn: "Produktnr",
                keyValue: "P001");
        }
    }
}
