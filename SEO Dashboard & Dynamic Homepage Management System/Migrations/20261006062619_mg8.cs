using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class mg8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "publicId",
                table: "vehicles",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "publicId",
                table: "vehicles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
