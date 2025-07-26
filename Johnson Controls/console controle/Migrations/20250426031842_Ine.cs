using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace console_controle.Migrations
{
    /// <inheritdoc />
    public partial class Ine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac346f6-36cd-475c-971e-5657e905a0a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bbb2fbf-ca4f-4f73-a968-0ce908daf5f4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3ac346f6-36cd-475c-971e-5657e905a0a8", "04ed9c0c-c808-4cdf-ad82-495ba178fdfe", "Recruiter", "Recruiter" },
                    { "3bbb2fbf-ca4f-4f73-a968-0ce908daf5f4", "bede7246-a626-45ca-bc75-4f0c65a05704", "HarringManger", "HarringManger" }
                });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 27, 5, 46, 34, 669, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 28, 5, 46, 34, 689, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 27, 5, 46, 34, 689, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 4,
                column: "InterviewDate",
                value: new DateTime(2025, 4, 28, 5, 46, 34, 689, DateTimeKind.Local).AddTicks(3540));
        }
    }
}
