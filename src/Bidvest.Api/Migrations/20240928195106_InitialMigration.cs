using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bidvest.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Todo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Action__FFE3F4D93EF34768", x => x.ActionId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item__727E838BCE9D9243", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "MeetingType",
                columns: table => new
                {
                    MeetingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MeetingT__D161C3E3ED0E7E97", x => x.MeetingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE1ABCEE635E", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsDefaultStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__C8EE2063F07396AF", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__1788CC4CB9D9A9F3", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingTypeId = table.Column<int>(type: "int", nullable: false),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduleStartDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduleEndDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    MinuteDuration = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meeting__E9F9E94CEECEB2FA", x => x.MeetingId);
                    table.ForeignKey(
                        name: "FK__Meeting__Meeting__4E88ABD4",
                        column: x => x.MeetingTypeId,
                        principalTable: "MeetingType",
                        principalColumn: "MeetingTypeId");
                });

            migrationBuilder.CreateTable(
                name: "ItemStatus",
                columns: table => new
                {
                    ItemStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemStat__80C775A3FF110F79", x => x.ItemStatusId);
                    table.ForeignKey(
                        name: "FK__ItemStatu__ItemI__5812160E",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK__ItemStatu__Statu__571DF1D5",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__0DC06FAC03850C2E", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK__Question__UserId__2C3393D0",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole__3D978A35AF01185A", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK__UserRole__RoleId__29572725",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK__UserRole__UserId__286302EC",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MeetingItem",
                columns: table => new
                {
                    MeetingItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemStatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ActionBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MeetingI__0D29BB38BFC6D13C", x => x.MeetingItemId);
                    table.ForeignKey(
                        name: "FK__MeetingIt__Actio__60A75C0F",
                        column: x => x.ActionBy,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__MeetingIt__ItemI__5EBF139D",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK__MeetingIt__ItemS__5FB337D6",
                        column: x => x.ItemStatusId,
                        principalTable: "ItemStatus",
                        principalColumn: "ItemStatusId");
                    table.ForeignKey(
                        name: "FK__MeetingIt__Meeti__5DCAEF64",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId");
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Option__92C7A1FF80E2C0C9", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK__Option__Question__2F10007B",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId");
                });

            migrationBuilder.CreateTable(
                name: "UserVote",
                columns: table => new
                {
                    UserVoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserVote__0F0C36ECDCE8DEB5", x => x.UserVoteId);
                    table.ForeignKey(
                        name: "FK__UserVote__Option__33D4B598",
                        column: x => x.OptionId,
                        principalTable: "Option",
                        principalColumn: "OptionId");
                    table.ForeignKey(
                        name: "FK__UserVote__Questi__32E0915F",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId");
                    table.ForeignKey(
                        name: "FK__UserVote__UserId__31EC6D26",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "MeetingType",
                columns: new[] { "MeetingTypeId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "M", "MANCO" },
                    { 2, "F", "Finance" },
                    { 3, "PTL", "Project Team Leaders" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "SystemAdmin" },
                    { 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemStatus_ItemId",
                table: "ItemStatus",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStatus_StatusId",
                table: "ItemStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_MeetingTypeId",
                table: "Meeting",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Meeting__A25C5AA7CC51BAC9",
                table: "Meeting",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItem_ActionBy",
                table: "MeetingItem",
                column: "ActionBy");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItem_ItemId",
                table: "MeetingItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItem_ItemStatusId",
                table: "MeetingItem",
                column: "ItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItem_MeetingId",
                table: "MeetingItem",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "UQ__MeetingT__A25C5AA7F48E1B23",
                table: "MeetingType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Option_QuestionId",
                table: "Option",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserId",
                table: "Question",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Status__05E7698AF7684F36",
                table: "Status",
                column: "StatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_OptionId",
                table: "UserVote",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_QuestionId",
                table: "UserVote",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVote_UserId",
                table: "UserVote",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "MeetingItem");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserVote");

            migrationBuilder.DropTable(
                name: "ItemStatus");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "MeetingType");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
