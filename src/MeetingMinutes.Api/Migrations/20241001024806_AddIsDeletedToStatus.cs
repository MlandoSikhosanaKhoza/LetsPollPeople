using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleteStatus",
                table: "Status",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Status",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "Item",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 1,
                columns: new[] { "IsCompleteStatus", "IsDeleted" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 2,
                columns: new[] { "IsCompleteStatus", "IsDeleted" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 3,
                columns: new[] { "IsCompleteStatus", "IsDeleted" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 4,
                columns: new[] { "IsCompleteStatus", "IsDeleted" },
                values: new object[] { true, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleteStatus",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Item");
        }
    }
}
