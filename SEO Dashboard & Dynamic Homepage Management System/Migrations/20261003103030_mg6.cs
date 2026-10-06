using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class mg6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "contactInformation",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "contactInformation",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
