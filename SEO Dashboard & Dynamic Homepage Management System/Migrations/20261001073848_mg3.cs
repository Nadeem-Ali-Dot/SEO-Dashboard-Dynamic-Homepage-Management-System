using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "seoSettings");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "seoSettings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "seoSettings");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "seoSettings");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "schemas");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "schemas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "schemas");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "schemas");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "occasions");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "occasions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "occasions");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "occasions");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "heroSections");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "heroSections");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "heroSections");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "heroSections");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "contactInformation");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "contactInformation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "contactInformation");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "contactInformation");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "aboutSections");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "aboutSections");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "aboutSections");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "aboutSections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "testimonials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "testimonials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "testimonials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "testimonials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "seoSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "seoSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "seoSettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "seoSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "schemas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "schemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "schemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "schemas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "occasions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "occasions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "occasions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "occasions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "heroSections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "heroSections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "heroSections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "heroSections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "galleries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "galleries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "galleries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "galleries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "contactInformation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "contactInformation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "contactInformation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "contactInformation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "aboutSections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "aboutSections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "aboutSections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "aboutSections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
