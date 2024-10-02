using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToMeetingType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MeetingType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MeetingType",
                keyColumn: "MeetingTypeId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MeetingType",
                keyColumn: "MeetingTypeId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MeetingType",
                keyColumn: "MeetingTypeId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MeetingType");
        }
    }
}
