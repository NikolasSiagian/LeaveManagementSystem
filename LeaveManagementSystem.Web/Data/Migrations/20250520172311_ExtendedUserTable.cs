using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3159fda0-b934-4a57-bc07-d0a3615cf231",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cbed872-1c61-4cb3-80b0-667be20f412f", new DateOnly(1992, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEJUfC6B0Rir3zp2+VSoU56LB9NQC6I+Ep9RqAxGgU0Xfucukcah9QiMAyBexv43i6w==", "fb2359a4-f6bd-4215-8171-0a339ecc92b8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3159fda0-b934-4a57-bc07-d0a3615cf231",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "951b7569-cf31-4f93-90a7-34e95a9be158", "AQAAAAIAAYagAAAAEClDjg3oNtWNZk1AxVGOcY1sdN8YMklOaccxn5m6jC4mjMfn0q9rmS27ObPqgAqHIw==", "e2c7670f-efab-4331-91e6-a03de13570b7" });
        }
    }
}
