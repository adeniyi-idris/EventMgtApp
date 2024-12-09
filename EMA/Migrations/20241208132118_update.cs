using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMA.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormatType",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "RegistyrationDate",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "IndustryType",
                table: "Registrations",
                newName: "RegistrationType");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptTerms",
                table: "Registrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Registrations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Registrations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequirements",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptTerms",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "SpecialRequirements",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "RegistrationType",
                table: "Registrations",
                newName: "IndustryType");

            migrationBuilder.AddColumn<int>(
                name: "FormatType",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistyrationDate",
                table: "Registrations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
