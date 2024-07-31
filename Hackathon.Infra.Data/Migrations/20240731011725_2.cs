using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Entrance",
                value: new DateTime(2024, 7, 30, 22, 17, 25, 121, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6968), new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6958) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6970), new DateTime(2024, 7, 30, 22, 17, 25, 7, DateTimeKind.Local).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Rj/gzvbsy3VcoSiU.mPNd.h2MAtu/xNPuPiXB0Ow9UhTssQKtVWTO");

            migrationBuilder.UpdateData(
                table: "Valet",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: new DateTime(2027, 7, 30, 22, 17, 25, 121, DateTimeKind.Local).AddTicks(4069));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Entrance",
                value: new DateTime(2024, 7, 30, 21, 7, 3, 519, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 30, 21, 7, 3, 251, DateTimeKind.Local).AddTicks(2572), new DateTime(2024, 7, 30, 21, 7, 3, 251, DateTimeKind.Local).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AlterDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 30, 21, 7, 3, 251, DateTimeKind.Local).AddTicks(2574), new DateTime(2024, 7, 30, 21, 7, 3, 251, DateTimeKind.Local).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$PN5odqrlOwUryo5NoctT/OQPDVIHM.qRja3cYu3Vpu7jnrlkVrt.K");

            migrationBuilder.UpdateData(
                table: "Valet",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: new DateTime(2027, 7, 30, 21, 7, 3, 519, DateTimeKind.Local).AddTicks(852));
        }
    }
}
