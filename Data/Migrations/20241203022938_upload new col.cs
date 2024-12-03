using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passport2.Data.Migrations
{
    /// <inheritdoc />
    public partial class uploadnewcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidencyApplications_UserDetails_UserDetailsId",
                table: "ResidencyApplications");

            migrationBuilder.DropColumn(
                name: "DateOfApplication",
                table: "ResidencyApplications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ResidencyApplications");

            migrationBuilder.RenameColumn(
                name: "ApplicationID",
                table: "ResidencyApplications",
                newName: "ResidencyApplicationID");

            migrationBuilder.AlterColumn<int>(
                name: "UserDetailsId",
                table: "ResidencyApplications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ResidencyApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ResidencyApplications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "ResidencyApplications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "PassportApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidencyApplications_UserDetails_UserDetailsId",
                table: "ResidencyApplications",
                column: "UserDetailsId",
                principalTable: "UserDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidencyApplications_UserDetails_UserDetailsId",
                table: "ResidencyApplications");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ResidencyApplications");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ResidencyApplications");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "ResidencyApplications");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "PassportApplications");

            migrationBuilder.RenameColumn(
                name: "ResidencyApplicationID",
                table: "ResidencyApplications",
                newName: "ApplicationID");

            migrationBuilder.AlterColumn<int>(
                name: "UserDetailsId",
                table: "ResidencyApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfApplication",
                table: "ResidencyApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ResidencyApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidencyApplications_UserDetails_UserDetailsId",
                table: "ResidencyApplications",
                column: "UserDetailsId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
