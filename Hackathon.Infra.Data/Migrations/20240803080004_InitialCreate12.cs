using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hackathon.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAccess",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoleAccess",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoleAccess",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 8, 3, 5, 0, 3, 418, DateTimeKind.Local).AddTicks(7652), new DateTime(2024, 8, 3, 5, 0, 3, 418, DateTimeKind.Local).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 8, 3, 5, 0, 3, 418, DateTimeKind.Local).AddTicks(7654), new DateTime(2024, 8, 3, 5, 0, 3, 418, DateTimeKind.Local).AddTicks(7653) });

            migrationBuilder.InsertData(
                table: "RoleAccess",
                columns: new[] { "Id", "RoleId", "Route" },
                values: new object[,]
                {
                    { 9, 2, "Appointment" },
                    { 10, 1, "Appointment" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rG98k9Z7uqgcEMbaFEbd5.0pSfurGxDcBAD2nTxukSEMLKIKDU6vu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$w1Lfre5Qf1YtqSrFIyTJ2.3tOjL.HbGhfy3Y4L4LkQKtdDWGSHzbq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleAccess",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RoleAccess",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 8, 3, 3, 55, 57, 0, DateTimeKind.Local).AddTicks(4520), new DateTime(2024, 8, 3, 3, 55, 57, 0, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 8, 3, 3, 55, 57, 0, DateTimeKind.Local).AddTicks(4522), new DateTime(2024, 8, 3, 3, 55, 57, 0, DateTimeKind.Local).AddTicks(4522) });

            migrationBuilder.InsertData(
                table: "RoleAccess",
                columns: new[] { "Id", "RoleId", "Route" },
                values: new object[,]
                {
                    { 2, 1, "Role" },
                    { 5, 1, "User" },
                    { 6, 1, "UserRole" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ggDJ5vR2trm0I.zE5xpB2evU6lkCt60aF/aNLlRrmIcQXj96Akgxa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$47qI/Jjg6V9ZyneZkAFai.8iJZkJqzEQJ7qEiJJ62IfUoDmFJv24u");
        }
    }
}
