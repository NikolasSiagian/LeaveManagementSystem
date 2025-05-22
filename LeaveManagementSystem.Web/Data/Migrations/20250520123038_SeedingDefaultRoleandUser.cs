using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRoleandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NUmberOfDays",
                table: "LeaveTypes",
                newName: "NumberOfDays");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0257c513-3596-404b-b8f6-368caa8efba1", null, "Admin", "ADMIN" },
                    { "d5064038-32d2-4545-a5f2-a33c62df1803", null, "Employee", "EMPLOYEE" },
                    { "d5cc9a1d-dabe-4a85-ba55-b19f73ced1db", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3159fda0-b934-4a57-bc07-d0a3615cf231", 0, "951b7569-cf31-4f93-90a7-34e95a9be158", "admin@gmail.test", true, false, null, "ADMIN@GMAIL.TEST", "ADMIN@GMAIL.TEST", "AQAAAAIAAYagAAAAEClDjg3oNtWNZk1AxVGOcY1sdN8YMklOaccxn5m6jC4mjMfn0q9rmS27ObPqgAqHIw==", null, false, "e2c7670f-efab-4331-91e6-a03de13570b7", false, "admin@gmail.test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0257c513-3596-404b-b8f6-368caa8efba1", "3159fda0-b934-4a57-bc07-d0a3615cf231" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5064038-32d2-4545-a5f2-a33c62df1803");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5cc9a1d-dabe-4a85-ba55-b19f73ced1db");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0257c513-3596-404b-b8f6-368caa8efba1", "3159fda0-b934-4a57-bc07-d0a3615cf231" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0257c513-3596-404b-b8f6-368caa8efba1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3159fda0-b934-4a57-bc07-d0a3615cf231");

            migrationBuilder.RenameColumn(
                name: "NumberOfDays",
                table: "LeaveTypes",
                newName: "NUmberOfDays");
        }
    }
}
