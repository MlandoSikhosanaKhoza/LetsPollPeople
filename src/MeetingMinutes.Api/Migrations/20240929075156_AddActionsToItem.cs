using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddActionsToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Action",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Action_ItemId",
                table: "Action",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK__Action__ItemId__5CD6CB2B",
                table: "Action",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Action__ItemId__5CD6CB2B",
                table: "Action");

            migrationBuilder.DropIndex(
                name: "IX_Action_ItemId",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Action");
        }
    }
}
