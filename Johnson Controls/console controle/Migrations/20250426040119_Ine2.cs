using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace console_controle.Migrations
{
    /// <inheritdoc />
    public partial class Ine2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b3538b-16d3-4084-a3ee-c2520ccadeae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8168dbbd-49a0-4163-96d6-dab6bda4cecf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5430fe36-540e-4b07-957e-0e93ac36302c", "b56c4b79-6119-48c5-a934-d1ec8a28ca67", "Recruiter", "Recruiter" },
                    { "fa2fc980-0d7a-44be-861d-ccc12cbcc4aa", "8400a40e-ec91-4616-b645-30be3b458d9f", "HarringManger", "HarringManger" }
                });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 27, 7, 1, 18, 914, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 28, 7, 1, 18, 916, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 27, 7, 1, 18, 916, DateTimeKind.Local).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 28, 7, 1, 18, 916, DateTimeKind.Local).AddTicks(9400));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5430fe36-540e-4b07-957e-0e93ac36302c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa2fc980-0d7a-44be-861d-ccc12cbcc4aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77b3538b-16d3-4084-a3ee-c2520ccadeae", "aab549c4-1654-4883-9904-5ac02e609e26", "Recruiter", "Recruiter" },
                    { "8168dbbd-49a0-4163-96d6-dab6bda4cecf", "33d7c1d6-41cb-4c96-b38c-0a19d52012de", "HarringManger", "HarringManger" }
                });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 27, 6, 18, 41, 587, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 28, 6, 18, 41, 590, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 27, 6, 18, 41, 590, DateTimeKind.Local).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 28, 6, 18, 41, 590, DateTimeKind.Local).AddTicks(6882));
        }
    }
}
