using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hackathon.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRM = table.Column<string>(type: "varchar(50)", nullable: false),
                    Specialty = table.Column<string>(type: "varchar(250)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInsuranceNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(250)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Route = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAccess_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    StartSunday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndSunday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartSunday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndSunday = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartMonday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndMonday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartMonday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndMonday = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartTuesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTuesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartTuesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndTuesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartWednesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndWednesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartWednesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndWednesday = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartThursday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndThursday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartThursday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndThursday = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartFriday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndFriday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartFriday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndFriday = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartSaturday = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndSaturday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStartSaturday = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEndSaturday = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultAvailability_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultAvailability_Doctor_Id",
                        column: x => x.Id,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificAvailability_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "CPF", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "12345678", "Doctor X", 1 },
                    { 2, "134567890", "Patient Y", 1 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "AlterDate", "CreateDate", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 2, 16, 49, 4, 555, DateTimeKind.Local).AddTicks(5600), new DateTime(2024, 8, 2, 16, 49, 4, 555, DateTimeKind.Local).AddTicks(5591), "Doctor" },
                    { 2, new DateTime(2024, 8, 2, 16, 49, 4, 555, DateTimeKind.Local).AddTicks(5603), new DateTime(2024, 8, 2, 16, 49, 4, 555, DateTimeKind.Local).AddTicks(5602), "Patient" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "CRM", "PersonId", "Specialty" },
                values: new object[] { 1, "123456", 1, "Clinico Geral" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "HealthInsuranceNumber", "PersonId" },
                values: new object[] { 1, "12313231231", 2 });

            migrationBuilder.InsertData(
                table: "RoleAccess",
                columns: new[] { "Id", "RoleId", "Route" },
                values: new object[,]
                {
                    { 1, 1, "Auth/RefreshToken" },
                    { 2, 1, "Role" },
                    { 3, 1, "Doctor" },
                    { 4, 1, "Patient" },
                    { 5, 1, "User" },
                    { 6, 1, "UserRole" },
                    { 7, 2, "Auth/RefreshToken" },
                    { 8, 2, "Patient" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PersonId", "RefreshToken", "RefreshTokenExpiryDate" },
                values: new object[,]
                {
                    { 1, "ricardomacieldasilva@hotmail.com", "$2a$11$eL05H1cLwy08PrehyOjaTuz8QKvnHcm1J9r/U7IbtzkUveDRYwTYO", 1, null, null },
                    { 2, "patienty@hotmail.com", "$2a$11$iD93J4.XWpTWraXnzK0PnO73/Kt9dH2t74Kb.Le9NRKFFM9xUt/Lq", 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "EndTime", "PatientId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 15, 0, 0, 0), 1, new TimeSpan(0, 14, 0, 0, 0) },
                    { 3, new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 12, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0) },
                    { 4, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 11, 0, 0, 0), 1, new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "DefaultAvailability",
                columns: new[] { "Id", "DoctorId", "EndFriday", "EndMonday", "EndSaturday", "EndSunday", "EndThursday", "EndTuesday", "EndWednesday", "LunchEndFriday", "LunchEndMonday", "LunchEndSaturday", "LunchEndSunday", "LunchEndThursday", "LunchEndTuesday", "LunchEndWednesday", "LunchStartFriday", "LunchStartMonday", "LunchStartSaturday", "LunchStartSunday", "LunchStartThursday", "LunchStartTuesday", "LunchStartWednesday", "StartFriday", "StartMonday", "StartSaturday", "StartSunday", "StartThursday", "StartTuesday", "StartWednesday" },
                values: new object[] { 1, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), null, null, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), null, null, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), null, null, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), null, null, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "SpecificAvailability",
                columns: new[] { "Id", "Date", "DoctorId", "EndTime", "IsAvailable", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false, null },
                    { 2, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 16, 0, 0, 0), true, new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId_AppointmentDate",
                table: "Appointment",
                columns: new[] { "DoctorId", "AppointmentDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId_AppointmentDate",
                table: "Appointment",
                columns: new[] { "PatientId", "AppointmentDate" });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultAvailabilities_DoctorId",
                table: "DefaultAvailability",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PersonId",
                table: "Doctor",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonId",
                table: "Patient",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccess_RoleId",
                table: "RoleAccess",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificAvailability_DoctorId",
                table: "SpecificAvailability",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "DefaultAvailability");

            migrationBuilder.DropTable(
                name: "RoleAccess");

            migrationBuilder.DropTable(
                name: "SpecificAvailability");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
