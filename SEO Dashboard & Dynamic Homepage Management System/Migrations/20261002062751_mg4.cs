using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "publicId",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "publicId",
                table: "occasions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "publicId",
                table: "heroSections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "publicId",
                table: "aboutSections",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "publicId",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "publicId",
                table: "occasions");

            migrationBuilder.DropColumn(
                name: "publicId",
                table: "heroSections");

            migrationBuilder.DropColumn(
                name: "publicId",
                table: "aboutSections");
        }
    }
}
