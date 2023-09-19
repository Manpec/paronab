using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationParonAB.Migrations
{
    /// <inheritdoc />
    public partial class LaTillUniqueFörBenämning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Benamning",
                table: "Produkter",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_Benamning",
                table: "Produkter",
                column: "Benamning",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produkter_Benamning",
                table: "Produkter");

            migrationBuilder.AlterColumn<string>(
                name: "Benamning",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
