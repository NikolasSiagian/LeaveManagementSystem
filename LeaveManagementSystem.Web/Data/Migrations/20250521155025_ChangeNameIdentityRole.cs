using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5cc9a1d-dabe-4a85-ba55-b19f73ced1db",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Supervisor", "SUPERVISOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3159fda0-b934-4a57-bc07-d0a3615cf231",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba7f7e44-d680-4cc5-9215-3d21884a0240", "AQAAAAIAAYagAAAAEJnMhbm0VZaVUvZulyJ4prjggGdKXPH6B9qwkeMBvUUhnkFWI4uMAmNoPLGX84GdaA==", "7da544c3-89c2-4a05-a8ee-7e3466c763dd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5cc9a1d-dabe-4a85-ba55-b19f73ced1db",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3159fda0-b934-4a57-bc07-d0a3615cf231",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cbed872-1c61-4cb3-80b0-667be20f412f", "AQAAAAIAAYagAAAAEJUfC6B0Rir3zp2+VSoU56LB9NQC6I+Ep9RqAxGgU0Xfucukcah9QiMAyBexv43i6w==", "fb2359a4-f6bd-4215-8171-0a339ecc92b8" });
        }
    }
}
